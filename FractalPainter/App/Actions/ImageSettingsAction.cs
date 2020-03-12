﻿using FractalPainting.Infrastructure.Common;
using FractalPainting.Infrastructure.UiActions;

namespace FractalPainting.App.Actions
{
    public class ImageSettingsAction : IUiAction
    {
        private IImageHolder imageHolder;
        private ImageSettings imageSettings;

        public ImageSettingsAction(IImageHolder imageHolder, ImageSettings imageSettings)
        {
            this.imageHolder = imageHolder;
            this.imageSettings = imageSettings;
        }

        public Category Category {get;} = Category.Settings;
        public string Name => "Изображение...";
        public string Description => "Размеры изображения";

        public void Perform()
        {
            SettingsForm.For(imageSettings).ShowDialog();
            imageHolder.RecreateImage(imageSettings);
        }
    }
}