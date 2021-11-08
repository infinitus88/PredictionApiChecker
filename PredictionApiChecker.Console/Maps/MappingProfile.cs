using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;
using System;
using AutoMapper;
using PredictionApiChecker.Api.Models.Football;
using PredictionApiChecker.Data.Models.Football;
using PredictionApiChecker.Data.Models;

namespace PredictionApiChecker.Console.Maps
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            PredictionRecordMappings();
        }

        private void PredictionRecordMappings()
        {
            CreateMap<PredictionRecordModel, PredictionRecord>()
                .ForMember(dst => dst.PredictionCoefficient, opt => opt.MapFrom(src => src.Odds[src.Prediction]))
                .ForMember(dst => dst.Prediction, opt => opt.MapFrom(src => src.Prediction.GetEnumValueFromDescription<OddType>()))
                .ForMember(dst => dst.Status, opt => opt.MapFrom(src => src.Status.GetEnumValueFromDescription<Status>()))
                .ForMember(dst => dst.StartDate, opt => opt.MapFrom(src => 
                    DateTime.ParseExact(src.StartDate, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture)))
                .ForMember(dst => dst.LastUpdateAt, opt => opt.MapFrom(src =>
                    DateTime.ParseExact(src.StartDate, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture)));
        }
    }

    internal static class StringExtensions
    {
        public static string Capitalize(this string input) =>
        input switch
        {
            null => throw new ArgumentNullException(nameof(input)),
            "" => throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input)),
            _ => input[0].ToString().ToUpper() + input.Substring(1)
        };

        public static T GetEnumValueFromDescription<T>(this string description) where T : Enum
        {
            foreach(var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // return default(T);
        }
    }

    internal static class EnumExtensions
    {
        
    }
}