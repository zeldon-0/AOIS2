using AOIS2.API.Contracts.Models.Kanjis;
using AOIS2.API.Contracts.Models.Radicals;
using AOIS2.Core.Domain.Models.JoinModels;
using AOIS2.Core.Domain.Models.Kanji;
using AOIS2.Core.Domain.Models.Radicals;
using AOIS2.Core.Domain.Models.SearchModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOIS2.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<KanjiWithReading, KanjiSearchModel>()
                .ForMember(dest => dest.Radicals,
                    opt => opt.MapFrom(src => src.KanjiWithReadingRadicals))
                .AfterMap((src, dest) =>
                    {
                        dest.Strokes = src
                        .KanjiWithReadingRadicals
                        .Sum(r => r.Radical.Strokes);
                    }
                );
            CreateMap<KanjiWithWords, KanjiSearchModel>()
                .ForMember(dest => dest.Radicals,
                    opt => opt.MapFrom(src => src.KanjiWithWordsRadicals))
                .ReverseMap();
            CreateMap<KanjiWithReadingAndWords, KanjiSearchModel>()
                 .ForMember(dest => dest.Radicals,
                    opt => opt.MapFrom(src => src.KanjiWithReadingAndWordsRadicals))
                .ReverseMap();

            CreateMap<KanjiWithReadingRadical, Radical>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.RadicalId))
                .ForMember(dest => dest.Character,
                    opt => opt.MapFrom(src => src.Radical.Character
                    )
                );
            CreateMap<KanjiWithWordsRadical, Radical>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.RadicalId))
                .ForMember(dest => dest.Character,
                    opt => opt.MapFrom(src => src.Radical.Character
                    )
                );

            CreateMap<KanjiWithReadingAndWordsRadical, Radical>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.RadicalId))
                .ForMember(dest => dest.Character,
                    opt => opt.MapFrom(src => src.Radical.Character
                    )
                );
            CreateMap<Radical, RadicalSearchModel>()
                .ForMember(dest => dest.KanjisWithReading,
                    opt => opt.MapFrom(
                        src => src.KanjiWithReadingRadicals
                        )
                )
                .ForMember(dest => dest.KanjisWithWords,
                    opt => opt.MapFrom(
                        src => src.KanjiWithWordsRadicals
                        )
                )
                .ForMember(dest => dest.KanjisWithReadingAndWords,
                    opt => opt.MapFrom(
                        src => src.KanjiWithReadingAndWordsRadicals
                        )
                )
                .AfterMap((src, dest) =>
               {
                   dest.Kanjis =
                       dest.KanjisWithReading
                       .Concat(dest.KanjisWithReadingAndWords)
                       .Concat(dest.KanjisWithWords);
               }
               );

            CreateMap<KanjiWithReadingRadical, KanjiSearchModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.KanjiWithReadingId));
            CreateMap<KanjiWithReadingRadical, KanjiSearchModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.KanjiWithReadingId));
            CreateMap<KanjiWithReadingRadical, KanjiSearchModel>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(
                        src => src.KanjiWithReadingId));

            CreateMap<KanjiSearchModel, KanjiResult>()
                .ForMember(dest => dest.Radicals,
                    opt => opt.MapFrom(src => src.Radicals));
            CreateMap<Radical, RadicalModel>();
        }
    }
}
