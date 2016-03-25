using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    public class Factory
    {

        TextToSpeech texttospeech;
        Callout callout;
        SettingsPage1 settingsScreen;
        QuitForm quitScreen;
        Browser browser;
        Email email;
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
            Email = new Email(true);
            //Settings must be created last to update all of the other application's properties
            SettingsScreen = new SettingsPage1();
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

        public SettingsPage1 SettingsScreen
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

        public Email Email
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
