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
        private IDetalleOrden _detallesordenes;
        private IDetalleVenta _detallesventas;
        private IEmpleado _empleados;
        private IEmpresa _empresas;
        private IEstado _estados;
        private IFormaPago _formaspagos;
        private IGenero _generos;
        private IInsumo _insumos;

        private IInsumoPrenda _insumoprendas;
        private IInsumoProveedor _insumoproveedores;
        private IInventario _inventarios;
        private IInventarioTalla _inventariotallas;
        private IMunicipio _municipios;
        private IOrden _ordenes;
        private IPais _paises;
        private IPrenda _prendas;
        private IProveedor _proveedores;
        private ITalla _tallas;
        private ITipoEstado _tiposestados;
        private ITipoPersona _tipospersonas;
        private ITipoProteccion _tiposprotecciones;
        private IVenta _ventas;

        public UnitOfWork(RopaContext context)
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
        public IDetalleOrden DetallesOrdenes{
            get{
                if(_detallesordenes == null){
                    _detallesordenes = new DetalleOrdenRepository(_context);
                }
                return _detallesordenes;
            }
        }
        public IDetalleVenta DetallesVentas{
            get{
                if(_detallesventas == null){
                    _detallesventas = new DetalleVentaRepository(_context);
                }
                return _detallesventas;
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
                if(_formaspagos == null){
                    _formaspagos = new FormaPagoRepository(_context);
                }
                return _formaspagos;
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
        public IInsumoProveedor InsumoProveedores{
            get{
                if(_insumoproveedores == null){
                    _insumoproveedores = new InsumoProveedorRepository(_context);
                }
                return _insumoproveedores;
            }
        }
        public IInsumoPrenda InsumoPrendas{
            get{
                if(_insumoprendas == null){
                    _insumoprendas = new InsumoPrendasRepository(_context);
                }
                return _insumoprendas;
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
        public IInventarioTalla InventarioTallas{
            get{
                if(_inventariotallas == null){
                    _inventariotallas = new InventarioTallaRepository(_context);
                }
                return _inventariotallas;
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
        public ITipoEstado TiposEstados{
            get{
                if(_tiposestados == null){
                    _tiposestados = new TipoEstadoRepository(_context);
                }
                return _tiposestados;
            }
        }
        public ITipoPersona TiposPersonas{
            get{
                if(_tipospersonas == null){
                    _tipospersonas = new TipoPersonaRepository(_context);
                }
                return _tipospersonas;
            }
        }
        public ITipoProteccion TiposProtecciones{
            get{
                if(_tiposprotecciones == null){
                    _tiposprotecciones = new TipoProteccionRepository(_context);
                }
                return _tiposprotecciones;
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