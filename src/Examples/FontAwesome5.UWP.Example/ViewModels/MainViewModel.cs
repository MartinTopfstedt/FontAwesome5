﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using FontAwesome5.Extensions;

namespace FontAwesome5.UWP.Example.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            AllIcons = Enum.GetValues(typeof(EFontAwesomeIcon)).Cast<EFontAwesomeIcon>()
                        .OrderBy(i => i.GetStyle()).ThenBy(i => i.GetLabel()).ToList();

            AllIcons.Remove(EFontAwesomeIcon.None);
            UpdateVisibleIcons();

            FlipOrientations = Enum.GetValues(typeof(EFlipOrientation)).Cast<EFlipOrientation>().ToList();
            SpinDuration = 5;
            PulseDuration = 5;
            FontSize = 30;
            Rotation = 0;
        }

        private EFontAwesomeIcon _selectedIcon;
        public EFontAwesomeIcon SelectedIcon
        {
            get => _selectedIcon;
            set
            {
                _selectedIcon = value;
                RaisePropertyChanged(nameof(SelectedIcon));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private bool _spinIsEnabled;
        public bool SpinIsEnabled
        {
            get => _spinIsEnabled;
            set
            {
                _spinIsEnabled = value;
                RaisePropertyChanged(nameof(SpinIsEnabled));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private double _spinDuration;
        public double SpinDuration
        {
            get => _spinDuration;
            set
            {
                _spinDuration = value;
                RaisePropertyChanged(nameof(SpinDuration));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private bool _pulseIsEnabled;
        public bool PulseIsEnabled
        {
            get => _pulseIsEnabled;
            set
            {
                _pulseIsEnabled = value;
                RaisePropertyChanged(nameof(PulseIsEnabled));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private double _pulseDuration;
        public double PulseDuration
        {
            get => _pulseDuration;
            set
            {
                _pulseDuration = value;
                RaisePropertyChanged(nameof(PulseDuration));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private EFlipOrientation _flipOrientation;
        public EFlipOrientation FlipOrientation
        {
            get => _flipOrientation;
            set
            {
                _flipOrientation = value;
                RaisePropertyChanged(nameof(FlipOrientation));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private double _fontSize;
        public double FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                RaisePropertyChanged(nameof(FontSize));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        private double _rotation;
        private string _filterText;

        public double Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                RaisePropertyChanged(nameof(Rotation));
                RaisePropertyChanged(nameof(FontText));
            }
        }

        public List<EFlipOrientation> FlipOrientations { get; set; } = new List<EFlipOrientation>();
        public List<EFontAwesomeIcon> AllIcons { get; set; } = new List<EFontAwesomeIcon>();

        public string FontText => $"<fa5:FontAwesome Icon=\"{SelectedIcon}\" Fontsize=\"{FontSize}\" Spin=\"{SpinIsEnabled}\" " + 
                                  $"SpinDuration=\"{SpinDuration}\" Pulse=\"{PulseIsEnabled}\" PulseDuration=\"{PulseDuration}\" FlipOrientation=\"{FlipOrientation}\" >";

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Visible Icon Filtering

        public List<EFontAwesomeIcon> VisibleIcons { get; private set; }

        public string FilterText
        {
          get => _filterText;
          set
          {
            _filterText = value;
            UpdateVisibleIcons();
          }
        }

        private void UpdateVisibleIcons()
        {
          var addAll = string.IsNullOrWhiteSpace(FilterText);

          //Confirm regex is valid
          if (!addAll)
          {
            try
            {
              _ = Regex.IsMatch(string.Empty, FilterText);
            }
            catch (Exception)
            {
              addAll = true;
            }
          }

          //Add all if no proper filter is applied
          VisibleIcons = addAll
            ? AllIcons
            : new List<EFontAwesomeIcon>(AllIcons.Where(icon => Regex.IsMatch(
              icon.GetInformation().Label
              , FilterText
              , RegexOptions.IgnoreCase
            )));

          SelectedIcon = VisibleIcons.FirstOrDefault();

          RaisePropertyChanged(nameof(VisibleIcons));
          RaisePropertyChanged(nameof(SelectedIcon));
        }

        #endregion
  }
}
