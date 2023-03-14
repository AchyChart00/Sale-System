using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaVenta.DTO;
using SistemaVenta.Model;

namespace SistemaVenta.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Rol
            //Convertir de Rol a DTO_Rol
            //CreateMap<Rol, DTO_Rol>();
            //Convertir de DTO_ROL a rol
            CreateMap<Rol, DTO_Rol>().ReverseMap();

            #endregion Rol

            #region Menu
            CreateMap<Menu, DTO_Menu>().ReverseMap();
            #endregion Menu

            #region Usuario
            CreateMap<Usuario, DTO_Usuario>()
                .ForMember(
                    fate => fate.RolDescription,
                    opt => opt.MapFrom(origin => origin.IdRolNavigation.Nombre)
                )
                .ForMember(
                    fate=> fate.EsActivo,
                    opt => opt.MapFrom(origin => origin.EsActivo == true? 1 : 0)
                );

            CreateMap<Usuario, DTO_Usuario>()
                .ForMember(
                    fate => fate.RolDescription,
                    opt => opt.MapFrom(origin => origin.IdRolNavigation.Nombre)
                );

            CreateMap<DTO_Usuario, Usuario>()
                .ForMember(
                    fate => fate.IdRolNavigation,
                    opt => opt.Ignore()
                )
                .ForMember(
                    fate => fate.EsActivo,
                    opt => opt.MapFrom(origin => origin.EsActivo == 1 ? true : false)
                )
                ;
            #endregion Usuario

            #region Categoria
            CreateMap<Categoria, DTO_Categoria>().ReverseMap();
            #endregion Categoria

            #region Producto
            CreateMap<Producto, DTO_Producto>()
                .ForMember(
                fate=> fate.DescripcionCategoria,
                opt =>opt.MapFrom(origin => origin.IdCategoriaNavigation.Nombre)
                )
                .ForMember(
                fate => fate.Precio,
                opt => opt.MapFrom(origin => Convert.ToString(origin.Precio.Value, new CultureInfo("es-MX")))
                );

            CreateMap<DTO_Producto, Producto>()
                .ForMember(
                fate => fate.IdCategoriaNavigation,
                opt => opt.Ignore()
                )
                .ForMember(
                fate => fate.Precio,
                opt => opt.MapFrom(origin => Convert.ToDecimal(origin.Precio, new CultureInfo("es-MX")))
                )
                .ForMember(
                fate => fate.EsActivo,
                opt => opt.MapFrom(origin => origin.EsActivo == 1 ? true : false)
                );
            #endregion Producto

            #region Venta
            CreateMap<Venta, DTO_Venta>()
                .ForMember(
                    fate => fate.TotalTexto,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("es-MX")))
                )
                .ForMember(
                    fate => fate.FechaRegistro,
                    opt => opt.MapFrom(origin => origin.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                );

            CreateMap<DTO_Venta, Venta>()
                .ForMember(
                    fate => fate.Total,
                    opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalTexto, new CultureInfo("es-MX")))
                );
            #endregion Venta

            #region DetalleVenta
            CreateMap<DetalleVenta, DTO_DetalleVenta>()
                .ForMember(
                    fate => fate.DescripcionProducto,
                    opt => opt.MapFrom(origin => origin.IdProductoNavigation.Nombre)
                )
                .ForMember(
                    fate => fate.PrecioTexto,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.Precio.Value, new CultureInfo("es-MX")))
                )
                .ForMember(
                    fate => fate.TotalTexto,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("es-MX")))
                );

            CreateMap<DTO_DetalleVenta, DetalleVenta>()
                .ForMember(
                    fate => fate.Precio,
                    opt => opt.MapFrom(origin => Convert.ToDecimal(origin.PrecioTexto, new CultureInfo("es-MX")))
                )
                .ForMember(
                    fate => fate.Total,
                    opt => opt.MapFrom(origin => Convert.ToDecimal(origin.TotalTexto, new CultureInfo("es-MX")))
                );
            #endregion DetalleVenta

            #region Reporte
            CreateMap<DetalleVenta, DTO_Reporte>()
                .ForMember(
                    fate => fate.FechaRegistro,
                    opt => opt.MapFrom(origin => origin.IdVentaNavigation.FechaRegistro.Value.ToString("dd/MM/yyyy"))
                )
                .ForMember(
                    fate => fate.NumeroDocumento,
                    opt => opt.MapFrom(origin => origin.IdVentaNavigation.NumeroDocumento)
                )
                .ForMember(
                    fate => fate.TipoPago,
                    opt => opt.MapFrom(origin => origin.IdVentaNavigation.TipoPago)
                )
                .ForMember(
                    fate => fate.TotalVenta,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.IdVentaNavigation.Total.Value, new CultureInfo("es-MX")))
                )
                .ForMember(
                    fate => fate.Producto,
                    opt => opt.MapFrom(origin => origin.IdProductoNavigation.Nombre)
                )
                .ForMember(
                    fate => fate.Precio,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.Precio.Value, new CultureInfo("es-MX")))
                )
                .ForMember(
                    fate => fate.Total,
                    opt => opt.MapFrom(origin => Convert.ToString(origin.Total.Value, new CultureInfo("es-MX")))
                );
            #endregion Reporte
        }
    }
}
