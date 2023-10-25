using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly FiltroClothingContext _context;
        private ICargo _cargos;
        private ICliente _clientes;
        private IColor _colores;
        private IDepartamento _departamentos;
        private IDetalleOrden _detalleordenes;
        private IDetalleVenta _detalleventas;
        private IEmpleado _empleados;
        private IEmpresa _empresas;
        private IEstado _estados;
        private IFormaPago _formapagos;
        private IGenero _generos;
        private IInsumo _insumos;
        private IInventario _inventarios;
        private IMunicipio _municipios;
        private IOrden _ordenes;
        private IPais _paises;
        private IPrenda _prendas;
        private IProveedor _proveedores;
        private ITalla _tallas;
        private ITipoEstado _tipoestados;
        private ITipoPersona _tipopersonas;
        private ITipoProteccion _tipoprotecciones;
        private IVenta _ventas;

        public UnitOfWork(FiltroClothingContext context)
        {
            _context = context;
        }
        public ICargo Cargos{
            get{
                if(_cargos == null){
                    _cargos = new CargoRepository(_context);
                }
                return _cargos;
            }
        }
        public ICliente Clientes{
            get{
                if(_clientes == null){
                    _clientes = new ClienteRepository(_context);
                }
                return _clientes;
            }
        }
        public IColor Colores{
            get{
                if(_colores == null){
                    _colores = new ColorRepository(_context);
                }
                return _colores;
            }
        }
        public IDepartamento Departamentos{
            get{
                if(_departamentos == null){
                    _departamentos = new DepartamentoRepository(_context);
                }
                return _departamentos;
            }
        }
        public IDetalleOrden DetalleOrdenes{
            get{
                if(_detalleordenes == null){
                    _detalleordenes = new DetalleOrdenRepository(_context);
                }
                return _detalleordenes;
            }
        }
        public IDetalleVenta DetalleVentas{
            get{
                if(_detalleventas == null){
                    _detalleventas = new DetalleVentaRepository(_context);
                }
                return _detalleventas;
            }
        }
        public IEmpleado Empleados{
            get{
                if(_empleados == null){
                    _empleados = new EmpleadoRepository(_context);
                }
                return _empleados;
            }
        }
        public IEmpresa Empresas{
            get{
                if(_empresas == null){
                    _empresas = new EmpresaRepository(_context);
                }
                return _empresas;
            }
        }
        public IEstado Estados{
            get{
                if(_estados == null){
                    _estados = new EstadoRepository(_context);
                }
                return _estados;
            }
        }
        public IFormaPago FormasPagos{
            get{
                if(_formapagos == null){
                    _formapagos = new FormaPagoRepository(_context);
                }
                return _formapagos;
            }
        }
        public IGenero Generos{
            get{
                if(_generos == null){
                    _generos = new GeneroRepository(_context);
                }
                return _generos;
            }
        }
        public IInsumo Insumos{
            get{
                if(_insumos == null){
                    _insumos = new InsumoRepository(_context);
                }
                return _insumos;
            }
        }

        public IInventario Inventarios{
            get{
                if(_inventarios == null){
                    _inventarios = new InventarioRepository(_context);
                }
                return _inventarios;
            }
        }
        
        public IMunicipio Municipios{
            get{
                if(_municipios == null){
                    _municipios = new MunicipioRepository(_context);
                }
                return _municipios;
            }
        }
        public IOrden Ordenes{
            get{
                if(_ordenes == null){
                    _ordenes = new OrdenRepository(_context);
                }
                return _ordenes;
            }
        }
        public IPais Paises{
            get{
                if(_paises == null){
                    _paises = new PaisRepository(_context);
                }
                return _paises;
            }
        }
        public IPrenda Prendas{
            get{
                if(_prendas == null){
                    _prendas = new PrendaRepository(_context);
                }
                return _prendas;
            }
        }
        public IProveedor Proveedores{
            get{
                if(_proveedores == null){
                    _proveedores = new ProveedorRepository(_context);
                }
                return _proveedores;
            }
        }
        public ITalla Tallas{
            get{
                if(_tallas == null){
                    _tallas = new TallaRepository(_context);
                }
                return _tallas;
            }
        }
        public ITipoEstado TipoEstados{
            get{
                if(_tipoestados == null){
                    _tipoestados = new TipoEstadoRepository(_context);
                }
                return _tipoestados;
            }
        }
        public ITipoPersona TipoPersonas{
            get{
                if(_tipopersonas == null){
                    _tipopersonas = new TipoPersonaRepository(_context);
                }
                return _tipopersonas;
            }
        }
        public ITipoProteccion TipoProtecciones{
            get{
                if(_tipoprotecciones == null){
                    _tipoprotecciones = new TipoProteccionRepository(_context);
                }
                return _tipoprotecciones;
            }
        }
        public IVenta Ventas{
            get{
                if(_ventas == null){
                    _ventas = new VentaRepository(_context);
                }
                return _ventas;
            }
        }


        public Task CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}