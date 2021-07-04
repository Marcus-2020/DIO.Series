using System;
using System.Collections.Generic;
using DataLibrary.Enums;
using SeriesMVC.Models;

namespace SeriesMVC.Utils
{
    public static class ListsOf
    {
        public static List<GenderView> GenderViews()
        {
            List<GenderView> genders = new List<GenderView>();

            foreach (int i in Enum.GetValues(typeof(Gender)))
            {
                genders.Add(new GenderView(description: Enum.GetName(typeof(Gender), i), (Gender)i));
            }

            return genders;
        }
    }
}