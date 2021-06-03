using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.IO;
using System.Diagnostics;

namespace AI_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechSynthesizer syn = new SpeechSynthesizer();
        SpeechRecognitionEngine rec = new SpeechRecognitionEngine();
        PromptBuilder pb = new PromptBuilder();
        private void button1_Click(object sender, EventArgs e)
        {
            syn.SelectVoiceByHints(VoiceGender.Male);
            Choices list = new Choices();
            list.Add(File.ReadAllLines(@"C:\AI project\command\commands.txt"));//location to commands.

            Grammar gm = new Grammar(new GrammarBuilder(list));
            try
            {   rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gm);
                rec.SpeechRecognized += Sr_SpeechReconized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }
            pb.ClearContent(); //Clears all content output from the buffer stream.
            pb.AppendText(richTextBox1.Text);
            syn.Speak(pb);
        }
        public void Say(string phrase)
        {
            syn.SpeakAsync(phrase);
        }
        private void Sr_SpeechReconized(object sender, SpeechRecognizedEventArgs e)
        {
            string speechSaid = e.Result.Text;
            switch (speechSaid) // Only commands which we programmed.
            {
                case ("hello"):
                    Say("hi");
                    break;
                case ("how are you"):
                    Say("good, how about you");
                    break;
                case ("open google search engine"):
                    Say("opening google");
                    Process.Start("https://www.google.com");
                    break;
                case ("open g mail"):
                    Say("opening g mail");
                    Process.Start("https://mail.google.com/mail/u/0/?ogbl#inbox");
                    break;
                case ("open outlook"):
                    Say("opening outlook");
                    Process.Start("https://outlook.office365.com/mail");
                    break;
                case ("open google drive"):
                    Say("opening google drive");
                    Process.Start("https://drive.google.com/drive/my-drive");
                    break;
                case ("open google photos"):
                    Say("opening google photos");
                    Process.Start("https://www.google.com/photos/about");
                    break;
                case ("open google maps"):
                    Say("opening google maps");
                    Process.Start("https://www.google.com/maps");
                    break;
                case ("open food panda"):
                    Say("opening food panda");
                    Process.Start("https://www.foodpanda.pk");
                    break;
                case ("open whatsapp"):
                    Say("opening whatsapp");
                    Process.Start("https://web.whatsapp.com/");
                    break;
                case ("open youtube"):
                    Say("opening youtube");
                    Process.Start("https://www.youtube.com");
                    break;
                case ("open facebook"):
                    Say("opening facebook");
                    Process.Start("https://www.facebook.com");
                    break;
                case ("open instagram"):
                    Say("opening instagram");
                    Process.Start("https://www.instagram.com");
                    break;
                case ("open s s u e t"):
                    Say("opening s s u e t  ");
                    Process.Start("https://www.ssuet.edu.pk");
                    break;
                case ("open v l e"):
                    Say("opening  v l e");
                    Process.Start("https://ssuet.org");
                    break;
                case ("open q o b e"):
                    Say("opening q o b e");
                    Process.Start("https://qualityobe.com/site/login");
                    break;
                case ("open s s u e t contact"):
                    Say("opening s s u e t contact ");
                    Process.Start("https://www.ssuet.edu.pk/contact-us");
                    break;
                case ("play adat"):
                    Say("playing adat  ");
                    Process.Start("https://www.youtube.com/watch?v=ChTRhMXp96s");
                    break;
                case ("play bad liar"):
                    Say("playing bad liar ");
                    Process.Start("https://www.youtube.com/watch?v=NQAYb9ok4s0");
                    break;
                case ("play waka waka"):
                    Say("playing waka waka");
                    Process.Start("https://www.youtube.com/watch?v=pRpeEdMmmQ0&list=RDMM&index=6");
                    break;
                case ("play darshan raval's playlist"):
                    Say("playing darshan raval's playlist ");
                    Process.Start("https://youtu.be/iZYt-S2V2SE");
                    break;
                case ("play arijit singh's playlist"):
                    Say("playing arijit singh's playlist ");
                    Process.Start("https://www.youtube.com/watch?v=HPkydJOXXNs");
                    break;
                case ("open grammarly"):
                    Say("opening grammarly");
                    Process.Start("https://app.grammarly.com");
                    break;
                case ("open p d f convertor"):
                    Say("opening p d f convertor");
                    Process.Start("https://www.ilovepdf.com/word_to_pdf");
                    break;
                case ("open pinterest"):
                    Say("opening pinterest");
                    Process.Start("https://www.pinterest.com");
                    break;
                case ("open online library"):
                    Say("opening online library");
                    Process.Start("https://z-lib.org/");
                    break;
                case ("open netflix"):
                    Say("opening netflix");
                    Process.Start("https://www.netflix.com/pk/");
                    break;
                case ("close this"):
                    Say("closing the program");
                    SendKeys.Send("%{F4}");
                    break;
            }
        }
    }
}
