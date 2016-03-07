using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    class Factory
    {

        TextToSpeech texttospeech;
        Callout callout;
        SettingsForm settingsScreen;
        QuitForm quitScreen;
        Browser browser;
        Email2 email;
        Notebook notebook;

        public Factory()
        {
            createAllObjects();
        }

        public void createAllObjects()
        {
            Texttospeech = new TextToSpeech(true);
            Notebook = new Notebook(true);
            Callout = new Callout(true);
            QuitScreen = new QuitForm();
            Browser = new Browser();
            Email = new Email2(true);
            //Settings must be created last to update all of the other application's properties
            SettingsScreen = new SettingsForm();
        }

        public TextToSpeech Texttospeech
        {
            get
            {
                return texttospeech;
            }

            private set
            {
                texttospeech = value;
            }
        }

        public Callout Callout
        {
            get
            {
                return callout;
            }

            private set
            {
                callout = value;
            }
        }

        public SettingsForm SettingsScreen
        {
            get
            {
                return settingsScreen;
            }

            private set
            {
                settingsScreen = value;
            }
        }

        public QuitForm QuitScreen
        {
            get
            {
                return quitScreen;
            }

            private set
            {
                quitScreen = value;
            }
        }

        public Browser Browser
        {
            get
            {
                return browser;
            }

            private set
            {
                browser = value;
            }
        }

        public Email2 Email
        {
            get
            {
                return email;
            }

            private set
            {
                email = value;
            }
        }

        public Notebook Notebook
        {
            get
            {
                return notebook;
            }

            private set
            {
                notebook = value;
            }
        }

        


    }
}
