﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinMediaPlayer.Controls
{
    public partial class ContentItem : AbsoluteLayout
    {
        public static readonly BindableProperty ContentImgProperty = BindableProperty.Create("ContentImg", typeof(string), typeof(ContentItem), default(ICollection<string>));
        public String ContentImg
        {
            set { SetValue(ContentImgProperty, value); }
            get { return (string)GetValue(ContentImgProperty); }
        }

        public static readonly BindableProperty ContentInfoProperty = BindableProperty.Create("ContentInfo", typeof(List<string>), typeof(ContentItem), default(List<string>));
        public List<string> ContentInfo
        {
            set { SetValue(ContentInfoProperty, value); }
            get { return (List<string>)GetValue(ContentInfoProperty); }
        }

        public static readonly BindableProperty ContentFocusedCommandProperty = BindableProperty.Create("ContentFocusedCommand", typeof(ICommand), typeof(ContentItem), default(ICommand));
        public ICommand ContentFocusedCommand
        {
            set { SetValue(ContentFocusedCommandProperty, value); }
            get { return (ICommand)GetValue(ContentFocusedCommandProperty); }
        }

        public static readonly BindableProperty ContentSelectedCommandProperty = BindableProperty.Create("ContentSelectedCommand", typeof(ICommand), typeof(ContentItem), default(ICommand));
        public ICommand ContentSelectedCommand
        {
            set { SetValue(ContentSelectedCommandProperty, value); }
            get { return (ICommand)GetValue(ContentSelectedCommandProperty); }
        }

        public ContentItem()
        {
            InitializeComponent();

            ImageBorder.BackgroundColor = Color.FromRgb(32, 32, 32);
            Dim.Color = Color.FromRgba(0, 0, 0, 128);

            PropertyChanged += ContentPropertyChanged;
        }

        public bool SetFocus()
        {
            return FocusArea.Focus();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width == -1 || height == -1)
                return;

            WidthRequest = height * 1.8;
        }

        private void OnItemClicked(object sender, EventArgs e)
        {
            ContentSelectedCommand?.Execute(this);
        }

        private void OnItemFocused(object sender, FocusEventArgs e)
        {
            ImageBorder.BackgroundColor = Color.FromRgb(234, 234, 234);
            Dim.Color = Color.FromRgba(0, 0, 0, 0);

            ContentFocusedCommand?.Execute(this);
        }

        private void OnItemUnfocused(object sender, FocusEventArgs e)
        {
            ImageBorder.BackgroundColor = Color.FromRgb(32, 32, 32);
            Dim.Color = Color.FromRgba(0, 0, 0, 128);
        }

        private void ContentPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("ContentImg"))
            {
                ContentImage.Source = ContentImg;
            }
        }
    }
}