using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diginovasi.BusinessObjects.Masters;
using Diginovasi.BusinessObjects.Sales;
using Diginovasi.DataTransferObjects.Masters;
using Diginovasi.DataTransferObjects.Sales;
using Diginovasi.Api.Models.Masters;
using Diginovasi.Api.Models.Sales;

namespace Diginovasi.Api.Configurations
{
    public class AutomapperConfiguration:Profile
    {
        public AutomapperConfiguration()
        {
            SatuanMapping();
            MaterialMapping();
            CustomerMapping();
            SalesOrderItemMapping();
            SalesOrderMapping();
        }
        private void SatuanMapping()
        {
            CreateMap<Satuan, SatuanDto>().ReverseMap();
            CreateMap<SatuanRequest, SatuanDto>();
        }
        private void MaterialMapping()
        {
            CreateMap<Material, MaterialDto>()
                .ForMember(dest => dest.SatuanId, src => src.MapFrom(c => c.Satuan == null ? 0:c.Satuan.Id))
                .ForMember(dest => dest.FormattedUrlGambar, src => src.MapFrom(c => GlobalAppScopedHelper.GetUploadedFile(c.UrlGambar)));
            CreateMap<MaterialDto, Material>();
            CreateMap<MaterialRequest, MaterialDto>();

        }
        private void CustomerMapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerRequest, CustomerDto>();
        }
        private void SalesOrderItemMapping()
        {
            CreateMap<SalesOrderItem, SalesOrderItemDto>()
                .ForMember(dest => dest.SalesOrderId, src => src.MapFrom(c => c.SalesOrder== null ? 0 : c.SalesOrder.Id))
                .ForMember(dest => dest.NoSalesOrder, src => src.MapFrom(c => c.SalesOrder == null ? string.Empty : c.SalesOrder.NoSalesOrder))
                .ForMember(dest => dest.MaterialId, src => src.MapFrom(c => c.Material == null ? 0 : c.Material.Id))
                .ForMember(dest => dest.DeskripsiMaterial, src => src.MapFrom(c => c.Material == null ? string.Empty : c.Material.Deskripsi))
                .ForMember(dest => dest.KodeMaterial, src => src.MapFrom(c => c.Material == null ? string.Empty : c.Material.Kode))
                .ForMember(dest => dest.KodeSatuan, src => src.MapFrom(c => c.Material == null ? string.Empty : (c.Material.Satuan == null ? string.Empty : c.Material.Satuan.Kode)))
                .ForMember(dest => dest.Harga, src => src.MapFrom(c => c.Material == null ? 0 : c.Material.Harga))
                .ForMember(nameof(SalesOrderItemDto.SubTotal), (entity) =>
                {
                    entity.MapFrom(src => src.Jumlah * (src.Material != null ? src.Material.Harga : 1));
                });
            CreateMap<SalesOrderItemDto, SalesOrderItem>();
            CreateMap<SalesOrderItemRequest, SalesOrderItemDto>();

        }
        private void SalesOrderMapping()
        {
            CreateMap<SalesOrder, SalesOrderDto>()
                .ForMember(dest => dest.TanggalStruct, src => src.MapFrom(c => new TanggalStructDto
                {
                    Year = c.Tanggal.Year,
                    Month = c.Tanggal.Month,
                    Day = c.Tanggal.Day
                }))
                .ForMember(dest => dest.NoCustomer, src => src.MapFrom(c => c.Customer != null ? c.Customer.NoCustomer : string.Empty))
                .ForMember(dest => dest.NamaCustomer, src => src.MapFrom(c => c.Customer != null ? c.Customer.Nama : string.Empty))
                .ForMember(dest => dest.Total, src => src.MapFrom(c => c.SalesOrderItems.Sum(i => i.Jumlah * (i.Material!=null ? i.Material.Harga : 1))));
            CreateMap<SalesOrderDto, SalesOrder>();
            CreateMap<SalesOrderRequest, SalesOrderDto>()
                .ForMember(dest => dest.Tanggal, src => src.MapFrom(c => new DateTime(c.TanggalStruct.Year, c.TanggalStruct.Month, c.TanggalStruct.Day)));
            CreateMap<TanggalStructDto, TanggalStructRequest>().ReverseMap();
        }
    }
}
