﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Services.Rest
{
    public interface ICloudinaryService
    {
        string StoreImage(string file);
        string StoreVideo(string file);

        string StoreResized(string file, int width, int height, string crop);
        string BuildUrl(string publicId, string crop = "fill", int width = 150, int height = 150);
        string BuildUrl(string publicId);
        string BuildUrlVideo(string publicId);
        void Delete(string publicId);
        string StoreFromUrl(string url);
    }

}
