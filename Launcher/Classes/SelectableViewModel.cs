// -----------------------------------------------------------
// Copyrights (c) 2016 Seditio 🍂 INC. All rights reserved.
// -----------------------------------------------------------

#region

using System.ComponentModel;
using System.Runtime.CompilerServices;

#endregion

namespace Launcher.Classes
{
    public sealed class SelectableViewModel : INotifyPropertyChanged
    {
        private string _host;
        private string _map;
        private string _ping;

        public string Host
        {
            get { return _host; }
            set
            {
                if(_host == value)
                    return;
                _host = value;
                OnPropertyChanged();
            }
        }

        public string Ping
        {
            get { return _ping; }
            set
            {
                if(_ping == value)
                    return;
                _ping = value;
                OnPropertyChanged();
            }
        }

        public string Map
        {
            get { return _map; }
            set
            {
                if(_map == value)
                    return;
                _map = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}