﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.Abstracts
{
    public interface IConfigHelper
    {
        T GetSettingsData<T>(string key, string parentProvider);
    }
}