using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using NAudio.Wave;

namespace DangKi_DangNhap
{
    public partial class CallGroup : Form
    {
        private UdpClient udpClient;
        private Thread receiveThread;
        private WaveInEvent waveIn;
        private WaveOutEvent waveOut;
        private BufferedWaveProvider waveProvider;
        private string userName;
        private bool isCalling;
        private const string MulticastIP = "224.0.0.1";
        private const int MulticastPort = 8000;

        public CallGroup()
        {
            InitializeComponent();
            InitializeAudio();
        }

        private void InitializeAudio()
        {
            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(44100, 1);
            waveIn.DataAvailable += WaveIn_DataAvailable;

            waveOut = new WaveOutEvent();
            waveProvider = new BufferedWaveProvider(new WaveFormat(44100, 1));
            waveOut.Init(waveProvider);
        }

        private void WaveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (isCalling && udpClient != null)
            {
                udpClient.Send(e.Buffer, e.Buffer.Length, MulticastIP, MulticastPort);
            }
        }

        private void StartCall()
        {
            try
            {
                udpClient = new UdpClient();
                udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                udpClient.ExclusiveAddressUse = false;
                udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, MulticastPort));
                udpClient.JoinMulticastGroup(IPAddress.Parse(MulticastIP));
                isCalling = true;
                waveIn.StartRecording();
                waveOut.Play();
                label2.Text = "Call started";

                receiveThread = new Thread(ReceiveAudio);
                receiveThread.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting call: {ex.Message}");
            }
        }

        private void StopCall()
        {
            try
            {
                isCalling = false;
                waveIn.StopRecording();
                waveOut.Stop();
                if (udpClient != null)
                {
                    udpClient.DropMulticastGroup(IPAddress.Parse(MulticastIP));
                    udpClient.Close();
                    udpClient = null; // Set udpClient to null after disposing
                }
                if (receiveThread != null && receiveThread.IsAlive)
                {
                    receiveThread.Abort();
                    receiveThread = null; // Set receiveThread to null after aborting
                }
                label2.Text = "Call stopped";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping call: {ex.Message}");
            }
        }

        private void ReceiveAudio()
        {
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, MulticastPort);
            while (isCalling)
            {
                try
                {
                    if (udpClient != null)
                    {
                        byte[] receivedBytes = udpClient.Receive(ref remoteEP);
                        waveProvider.AddSamples(receivedBytes, 0, receivedBytes.Length);
                    }
                }
                catch (ObjectDisposedException)
                {
                    // Handle ObjectDisposedException if needed
                    break; // Exit the loop if udpClient is disposed
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Receive error: {ex.Message}");
                    break; // Exit the loop on any other exception
                }
            }
        }

        private void bunifuButton24_Click(object sender, EventArgs e)
        {
            StartCall();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            StopCall();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Optional: Handle label click event if needed
        }
    }
}
