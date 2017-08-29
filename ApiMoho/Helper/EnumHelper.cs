using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMoho.Models;
using ApiMoho.Models.Enums;

namespace ApiMoho.Helper
{
    public static class EnumHelper
    {
        public static string GetCityEnumString(int num)
        {
            switch (num)
            {
                case (int) CityEnum.Winnipeg:
                    return "Winnipeg";
                case (int) CityEnum.Brandon:
                    return "Brandon";
                case (int) CityEnum.CarmanArea:
                    return "Carman Area";
                case (int) CityEnum.PembinaValley:
                    return "Pembina Valley";
                default:
                    return "Other";
            }
        }

        public static string GetProvinceEnumString(int num)
        {
            switch (num)
            {
                case (int) ProvinceEnum.Alberta:
                    return "Alberta";
                case (int) ProvinceEnum.Manitoba:
                    return "Manitoba";
                case (int) ProvinceEnum.Saskatchewan:
                    return "Saskatchewan";
                default:
                    return "Other";
            }
        }

        public static string GetCountryEnumString(int num)
        {
            switch (num)
            {
                case (int) CountryEnum.Canada:
                    return "Canada";
                default:
                    return "Other";
            }
        }

        public static string GetListingEnumString(int num)
        {
            switch (num)
            {
                case (int) ListingTypeEnum.Car:
                    return "Cars and Trucks";
                case (int)ListingTypeEnum.HomeRenovation:
                    return "Home Renovation";
                case (int)ListingTypeEnum.Plumbing:
                    return "Plumbing";
                case (int)ListingTypeEnum.Repairs:
                    return "Repairs";
                default:
                    return "Other";
            }
        }

        public static int GetListingEnumInt(string name)
        {
            if (name.Equals("Cars and Trucks"))
            {
                return (int)ListingTypeEnum.Car;
            }
            if (name.Equals("Home Renovation"))
            {
                return (int)ListingTypeEnum.HomeRenovation;
            }
            if (name.Equals("Plumbing"))
            {
                return (int)ListingTypeEnum.Plumbing;
            }
            if (name.Equals("Repairs"))
            {
                return (int) ListingTypeEnum.Repairs;
            }
            else
            {
                return 0;
            }
        }

        public static int GetCountryEnumInt(string name)
        {
            if (name.Equals("Canada"))
            {
                return (int) CountryEnum.Canada;
            }
            else
            {
                return 0;
            }
        }

        public static int GetProvinceEnumInt(string name)
        {
            if (name.Equals("Alberta"))
            {
                return (int)ProvinceEnum.Alberta;
            }
            if (name.Equals("Manitoba"))
            {
                return (int)ProvinceEnum.Manitoba;
            }
            if (name.Equals("Saskatchewan"))
            {
                return (int)ProvinceEnum.Saskatchewan;
            }
            else
            {
                return 0;
            }
        }

        public static int GetCityEnumInt(string name)
        {
            if (name.Equals("Winnipeg"))
            {
                return (int)CityEnum.Winnipeg;
            }
            if (name.Equals("Brandon"))
            {
                return (int)CityEnum.Brandon;
            }
            if (name.Equals("Carman Area"))
            {
                return (int)CityEnum.CarmanArea;
            }
            if (name.Equals("Prembina Valley"))
            {
                return (int)CityEnum.PembinaValley;
            }
            else
            {
                return 0;
            }
        }
    }
}