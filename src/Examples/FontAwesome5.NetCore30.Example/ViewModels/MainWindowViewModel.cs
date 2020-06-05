using FontAwesome5.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FontAwesome5.NetCore30.Example.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            AllIcons = Enum.GetValues(typeof(EFontAwesomeIcon)).Cast<EFontAwesomeIcon>()
                        .OrderBy(i => i.GetStyle()).ThenBy(i => i.GetLabel()).ToList();
            AllIcons.Remove(EFontAwesomeIcon.None);
            SelectedIcon = AllIcons.First();

            FlipOrientations = Enum.GetValues(typeof(EFlipOrientation)).Cast<EFlipOrientation>().ToList();
            SpinDuration = 5;
            PulseDuration = 5;

            FontSize = 30;
            Rotation = 0;

            Visibilities = Enum.GetValues(typeof(Visibility)).Cast<Visibility>().ToList();
            Visibility = Visibility.Visible;
        }

        public Visibility Visibility { get; set; }
        public EFontAwesomeIcon SelectedIcon { get; set; }

        public bool SpinIsEnabled { get; set; }
        public double SpinDuration { get; set; }
        public bool PulseIsEnabled { get; set; }
        public double PulseDuration { get; set; }
        public EFlipOrientation FlipOrientation { get; set; }
        public double FontSize { get; set; }
        public double Rotation { get; set; }

        public List<Visibility> Visibilities { get; set; } = new List<Visibility>();
        public List<EFlipOrientation> FlipOrientations { get; set; } = new List<EFlipOrientation>();
        public List<EFontAwesomeIcon> AllIcons { get; set; } = new List<EFontAwesomeIcon>();

        public string SVGText => $"<fa5:SvgAwesome Icon=\"{SelectedIcon}\" Height=\"100\" Width=\"100\">";
        public string ImageText => $"<fa5:ImageAwesome Icon=\"{SelectedIcon}\" Height=\"100\" Width=\"100\">";
        public string FontText => $"<fa5:FontAwesome Icon=\"{SelectedIcon}\" FontSize=\"{FontSize}\">";

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
