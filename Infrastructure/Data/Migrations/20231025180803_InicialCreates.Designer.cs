﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(FiltroClothingContext))]
    [Migration("20231025180803_InicialCreates")]
    partial class InicialCreates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("SueldoBase")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Cargo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("date");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdTipoPersona");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Color", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Color", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("NombreDep")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("Core.Entities.DetalleOrden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CantidadProducida")
                        .HasColumnType("int");

                    b.Property<int>("CantidadProducir")
                        .HasColumnType("int");

                    b.Property<int>("IdColor")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdOrden");

                    b.HasIndex("IdPrenda");

                    b.ToTable("DetalleOrden", (string)null);
                });

            modelBuilder.Entity("Core.Entities.DetalleVenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdInventario")
                        .HasColumnType("int");

                    b.Property<int>("IdTalla")
                        .HasColumnType("int");

                    b.Property<int>("IdVenta")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnitario")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdInventario");

                    b.HasIndex("IdTalla");

                    b.HasIndex("IdVenta");

                    b.ToTable("DetalleVenta", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("date");

                    b.Property<int>("IdCargo")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("MunicipioId")
                        .HasColumnType("int");

                    b.Property<string>("NombreEmp")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCargo");

                    b.HasIndex("IdEmpleado")
                        .IsUnique();

                    b.HasIndex("MunicipioId");

                    b.ToTable("Empleado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("Nit")
                        .HasColumnType("int");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("RepresentanteLegal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("Nit")
                        .IsUnique();

                    b.ToTable("Empresa", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("IdTipoEstado")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoEstado");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.FormaPago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("FormaPago", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Insumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreInsumo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("StockMax")
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasColumnType("int");

                    b.Property<double>("ValorUnit")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Insumo", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InsumoPrenda", b =>
                {
                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.Property<int>("IdInsumo")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdPrenda", "IdInsumo");

                    b.HasIndex("IdInsumo");

                    b.ToTable("InsumoPrenda", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InsumoProveedor", b =>
                {
                    b.Property<int>("IdInsumo")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdInsumo", "IdProveedor");

                    b.HasIndex("IdProveedor");

                    b.ToTable("InsumoProveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CodInv")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.Property<double>("ValorVtaCop")
                        .HasColumnType("double");

                    b.Property<double>("ValorVtaUsd")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CodInv")
                        .IsUnique();

                    b.HasIndex("IdPrenda");

                    b.ToTable("Inventario", (string)null);
                });

            modelBuilder.Entity("Core.Entities.InventarioTalla", b =>
                {
                    b.Property<int>("IdInventario")
                        .HasColumnType("int");

                    b.Property<int>("IdTalla")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdInventario", "IdTalla");

                    b.HasIndex("IdTalla");

                    b.ToTable("InventarioTalla", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NombreMun")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.ToTable("Municipio", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaOrden")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdOrden")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdEstado");

                    b.ToTable("Orden");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdGenero")
                        .HasColumnType("int");

                    b.Property<int>("IdPrenda")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoProteccion")
                        .HasColumnType("int");

                    b.Property<string>("NombrePrenda")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("ValorUnitCop")
                        .HasColumnType("double");

                    b.Property<double>("ValorUnitUsd")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.HasIndex("IdGenero");

                    b.HasIndex("IdPrenda")
                        .IsUnique();

                    b.HasIndex("IdTipoProteccion");

                    b.ToTable("prenda", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdMunicipio")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<int>("NitProveedor")
                        .HasColumnType("int");

                    b.Property<string>("NombreProveedor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdMunicipio");

                    b.HasIndex("IdTipoPersona");

                    b.HasIndex("NitProveedor")
                        .IsUnique();

                    b.ToTable("Proveedor", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Talla", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Talla", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoEstado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoEstado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreTipoPersona")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TipoPersona", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoProteccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TipoProteccion", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdFormaPago")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdEmpleado");

                    b.HasIndex("IdFormaPago");

                    b.ToTable("Venta", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.HasOne("Core.Entities.Municipio", "Municipios")
                        .WithMany("Clientes")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersonas")
                        .WithMany("Clientes")
                        .HasForeignKey("IdTipoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipios");

                    b.Navigation("TipoPersonas");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Paises")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paises");
                });

            modelBuilder.Entity("Core.Entities.DetalleOrden", b =>
                {
                    b.HasOne("Core.Entities.Color", "Colores")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Estado", "Estados")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Orden", "Ordenes")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdOrden")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Prenda", "Prendas")
                        .WithMany("DetalleOrdenes")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colores");

                    b.Navigation("Estados");

                    b.Navigation("Ordenes");

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.DetalleVenta", b =>
                {
                    b.HasOne("Core.Entities.Inventario", "Inventarios")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdInventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Talla", "Tallas")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdTalla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Venta", "Ventas")
                        .WithMany("DetalleVentas")
                        .HasForeignKey("IdVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventarios");

                    b.Navigation("Tallas");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.HasOne("Core.Entities.Cargo", "Cargos")
                        .WithMany("Empleados")
                        .HasForeignKey("IdCargo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Municipio", "Municipios")
                        .WithMany("Empleados")
                        .HasForeignKey("MunicipioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargos");

                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Core.Entities.Empresa", b =>
                {
                    b.HasOne("Core.Entities.Municipio", "Municipios")
                        .WithMany("Empresas")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.HasOne("Core.Entities.TipoEstado", "TipoEstados")
                        .WithMany("Estados")
                        .HasForeignKey("IdTipoEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoEstados");
                });

            modelBuilder.Entity("Core.Entities.InsumoPrenda", b =>
                {
                    b.HasOne("Core.Entities.Insumo", "Insumos")
                        .WithMany("InsumoPrendas")
                        .HasForeignKey("IdInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Prenda", "Prendas")
                        .WithMany("InsumoPrendas")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumos");

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.InsumoProveedor", b =>
                {
                    b.HasOne("Core.Entities.Insumo", "Insumos")
                        .WithMany("InsumoProveedores")
                        .HasForeignKey("IdInsumo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Proveedor", "Proveedores")
                        .WithMany("InsumoProveedores")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Insumos");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.HasOne("Core.Entities.Prenda", "Prendas")
                        .WithMany("Inventarios")
                        .HasForeignKey("IdPrenda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.InventarioTalla", b =>
                {
                    b.HasOne("Core.Entities.Inventario", "Inventarios")
                        .WithMany("InventarioTallas")
                        .HasForeignKey("IdInventario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Talla", "Tallas")
                        .WithMany("InventarioTallas")
                        .HasForeignKey("IdTalla")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inventarios");

                    b.Navigation("Tallas");
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.HasOne("Core.Entities.Departamento", "Departamentos")
                        .WithMany("Municipios")
                        .HasForeignKey("IdDepartamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Empleado", "Empleados")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Estado", "Estados")
                        .WithMany("Ordenes")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estados")
                        .WithMany("Prendas")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Genero", "Generos")
                        .WithMany("Prendas")
                        .HasForeignKey("IdGenero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoProteccion", "TiposProtecciones")
                        .WithMany("Prendas")
                        .HasForeignKey("IdTipoProteccion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Generos");

                    b.Navigation("TiposProtecciones");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.HasOne("Core.Entities.Municipio", "Municipios")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdMunicipio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersonas")
                        .WithMany("Proveedores")
                        .HasForeignKey("IdTipoPersona")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Municipios");

                    b.Navigation("TipoPersonas");
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.HasOne("Core.Entities.Cliente", "Clientes")
                        .WithMany("Ventas")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Empleado", "Empleados")
                        .WithMany("Ventas")
                        .HasForeignKey("IdEmpleado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FormaPago", "FormaPagos")
                        .WithMany("Ventas")
                        .HasForeignKey("IdFormaPago")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("FormaPagos");
                });

            modelBuilder.Entity("Core.Entities.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("Core.Entities.Cliente", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Color", b =>
                {
                    b.Navigation("DetalleOrdenes");
                });

            modelBuilder.Entity("Core.Entities.Departamento", b =>
                {
                    b.Navigation("Municipios");
                });

            modelBuilder.Entity("Core.Entities.Empleado", b =>
                {
                    b.Navigation("Ordenes");

                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("DetalleOrdenes");

                    b.Navigation("Ordenes");

                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.FormaPago", b =>
                {
                    b.Navigation("Ventas");
                });

            modelBuilder.Entity("Core.Entities.Genero", b =>
                {
                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.Insumo", b =>
                {
                    b.Navigation("InsumoPrendas");

                    b.Navigation("InsumoProveedores");
                });

            modelBuilder.Entity("Core.Entities.Inventario", b =>
                {
                    b.Navigation("DetalleVentas");

                    b.Navigation("InventarioTallas");
                });

            modelBuilder.Entity("Core.Entities.Municipio", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Empleados");

                    b.Navigation("Empresas");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.Orden", b =>
                {
                    b.Navigation("DetalleOrdenes");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Core.Entities.Prenda", b =>
                {
                    b.Navigation("DetalleOrdenes");

                    b.Navigation("InsumoPrendas");

                    b.Navigation("Inventarios");
                });

            modelBuilder.Entity("Core.Entities.Proveedor", b =>
                {
                    b.Navigation("InsumoProveedores");
                });

            modelBuilder.Entity("Core.Entities.Talla", b =>
                {
                    b.Navigation("DetalleVentas");

                    b.Navigation("InventarioTallas");
                });

            modelBuilder.Entity("Core.Entities.TipoEstado", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Navigation("Clientes");

                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Core.Entities.TipoProteccion", b =>
                {
                    b.Navigation("Prendas");
                });

            modelBuilder.Entity("Core.Entities.Venta", b =>
                {
                    b.Navigation("DetalleVentas");
                });
#pragma warning restore 612, 618
        }
    }
}
