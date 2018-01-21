using System.Windows;
using Microsoft.Gestures.Endpoint;
using Microsoft.Gestures;

namespace GreetDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RunProgram();
        }

        private async void RunProgram()
        {
            var fist = new HandPose("Fist", new FingerPose(new AllFingersContext(), FingerFlexion.Folded));

            var peace = new HandPose("Peace", 
                new FingerPose(new[] { Finger.Index, Finger.Middle }, FingerFlexion.Open),
                new FingerPose(new[] { Finger.Thumb, Finger.Ring, Finger.Pinky}, FingerFlexion.Folded));

            var makePeace = new Gesture("makePeace", fist, peace);

            var gesturesService = GesturesServiceEndpointFactory.Create();
            await gesturesService.ConnectAsync();
            await gesturesService.RegisterGesture(makePeace);
/*
            makePeace.Triggered += (sender, args) =>
            {
                Dispatcher.Invoke(() => GreetingText.Text = "Hello MixUG");
            };
            */
            fist.Triggered += (sender, args) =>
            {
                Dispatcher.Invoke(() => GreetingText.Text = ".");
            };

            peace.Triggered += (sender, args) =>
            {
                Dispatcher.Invoke(() => GreetingText.Text = "..");
            };

        }
    }
}
