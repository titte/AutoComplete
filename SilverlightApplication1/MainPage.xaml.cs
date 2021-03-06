﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class MainPage : UserControl
    {
        private ViewModel _vm = null;
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _vm = new ViewModel();
            DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.GC.Collect();
        }
    }

    public class ViewModel : BaseViewModel
    {
        public ViewModel()
        {
            var list = new List<AutoCompleteItem>();
            list.Add(new AutoCompleteItem(1,"12345 Mathias Andersson"));
            list.Add(new AutoCompleteItem(2, "12366 Nils Andersson"));
            list.Add(new AutoCompleteItem(3, "12346 Freddan Olsson"));
            list.Add(new AutoCompleteItem(4, "22341 Greken Andersson"));
            list.Add(new AutoCompleteItem(5, "22345 Karl-Oskar Andersson"));
            Names = new ObservableCollection<AutoCompleteItem>(list);
            SelectedX = list[2];
            
        }

        private ObservableCollection<AutoCompleteItem> _items;
        private AutoCompleteItem _selectedX;

        public ObservableCollection<AutoCompleteItem> Names
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Names); }
        }

        public AutoCompleteItem SelectedX
        {
            get { return _selectedX; }
            set { _selectedX = value; RaisePropertyChanged(() => SelectedX); }
        }
    }
}
