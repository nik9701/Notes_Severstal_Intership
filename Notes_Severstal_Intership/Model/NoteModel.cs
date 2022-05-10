using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Notes_Severstal_Intership.Model
{
    internal class NoteModel: INotifyPropertyChanged
    {
        public DateTime ChangeDate { get; set; } = DateTime.Now;

        private bool _isDone;
        private string _text;

        public bool IsDone
        {
            get { return _isDone; }
            set 
            {
                if (_isDone == value)
                    return;
                _isDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public string Note
        {
            get { return _text; }
            set 
            {
                if (_text == value)
                    return;
                _text = value; 
                OnPropertyChanged("Note");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName="")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
