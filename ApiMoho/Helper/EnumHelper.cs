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
                case (int) CityEnum.Alton:
                    return "Altona";
                case (int) CityEnum.Winkler:
                    return "Winkler";
                case (int) CityEnum.Winnipeg:
                    return "Winnipeg";
                case (int) CityEnum.Carman:
                    return "Carman";
                case (int) CityEnum.Morden:
                    return "Morden";
                case (int) CityEnum.Brandon:
                    return "Brandon";
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
                case (int)ListingTypeEnum.Construction:
                    return "Construction and Maintaince";
                case (int)ListingTypeEnum.Garden:
                    return "Garden work and Misc";
                case (int)ListingTypeEnum.House:
                    return "House work/renovation";
                case (int)ListingTypeEnum.Other:
                    return "Other";
                case (int)ListingTypeEnum.Renovation:
                    return "Renovation";
                default:
                    return "Other";
            }
        }

        public static int GetListingEnumInt(string name)
        {
            try
            {
                switch (Enum.Parse(typeof(CityEnum), name))
                {
                    case CityEnum.Alton:
                        return (int)CityEnum.Alton;
                    case CityEnum.Winnipeg:
                        return (int)CityEnum.Winnipeg;
                    case CityEnum.Brandon:
                        return (int)CityEnum.Brandon;
                    case CityEnum.Carman:
                        return (int)CityEnum.Carman;
                    case CityEnum.Winkler:
                        return (int)CityEnum.Winkler;
                    case CityEnum.Morden:
                        return (int)CityEnum.Morden;
                    default:
                        return (int)CityEnum.Other;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public static int GetCountryEnumInt(string name)
        {
            try
            {
                switch (Enum.Parse(typeof(CityEnum), name))
                {
                    case CityEnum.Alton:
                        return (int)CityEnum.Alton;
                    case CityEnum.Winnipeg:
                        return (int)CityEnum.Winnipeg;
                    case CityEnum.Brandon:
                        return (int)CityEnum.Brandon;
                    case CityEnum.Carman:
                        return (int)CityEnum.Carman;
                    case CityEnum.Winkler:
                        return (int)CityEnum.Winkler;
                    case CityEnum.Morden:
                        return (int)CityEnum.Morden;
                    default:
                        return (int)CityEnum.Other;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public static int GetProvinceEnumInt(string name)
        {
            try
            {
                switch (Enum.Parse(typeof(CityEnum), name))
                {
                    case CityEnum.Alton:
                        return (int)CityEnum.Alton;
                    case CityEnum.Winnipeg:
                        return (int)CityEnum.Winnipeg;
                    case CityEnum.Brandon:
                        return (int)CityEnum.Brandon;
                    case CityEnum.Carman:
                        return (int)CityEnum.Carman;
                    case CityEnum.Winkler:
                        return (int)CityEnum.Winkler;
                    case CityEnum.Morden:
                        return (int)CityEnum.Morden;
                    default:
                        return (int)CityEnum.Other;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public static int GetCityEnumInt(string name)
        {
            try
            {
                switch (Enum.Parse(typeof(CityEnum), name))
                {
                    case CityEnum.Alton:
                        return (int) CityEnum.Alton;
                    case CityEnum.Winnipeg:
                        return (int) CityEnum.Winnipeg;
                    case CityEnum.Brandon:
                        return (int) CityEnum.Brandon;
                    case CityEnum.Carman:
                        return (int) CityEnum.Carman;
                    case CityEnum.Winkler:
                        return (int) CityEnum.Winkler;
                    case CityEnum.Morden:
                        return (int) CityEnum.Morden;
                    default:
                        return (int) CityEnum.Other;
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

        }
    }
}