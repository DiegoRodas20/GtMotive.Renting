# GtMotive.Renting

## Descripci�n del Proyecto
GtMotive.Renting es un sistema modular y escalable dise�ado para gestionar de manera eficiente el proceso de alquiler de veh�culos. Este sistema utiliza una arquitectura modular basada en los principios de **Clean Architecture** para garantizar la separaci�n de responsabilidades, alta mantenibilidad y escalabilidad.

El proyecto est� compuesto por tres m�dulos principales:
- **Vehicles**: Gestiona la flota de veh�culos y sus categor�as.
- **Rentals**: Administra las reservas y los alquileres de los veh�culos.
- **Customers**: Maneja la informaci�n y las actividades de los clientes.

Cada m�dulo est� dise�ado para ser desacoplado y organizado en capas seg�n los principios de Clean Architecture, asegurando independencia y flexibilidad en su desarrollo.

---

## Arquitectura
El sistema est� construido utilizando los principios de **Clean Architecture**, organizando el c�digo en capas para maximizar la independencia de los m�dulos y reducir el acoplamiento entre ellos.

### Tecnolog�as Utilizadas
- **Framework**: .NET Core
- **Base de Datos**: PostgreSQL
- **Cache Distribuida**: Redis
- **Mensajer�a**: RabbitMQ (para soporte de patrones de integraci�n interna si es necesario)
- **Contenedores**: Docker

### Diagrama de Arquitectura
El sistema est� compuesto por los siguientes componentes organizados seg�n los principios de Clean Architecture:
1. **Vehicles**: M�dulo para gestionar la flota de veh�culos y sus categor�as.
2. **Rentals**: M�dulo para administrar las reservas y alquileres.
3. **Customers**: M�dulo para manejar la informaci�n de los clientes y su historial.
4. **Distributed Cache**: Redis para acelerar el acceso a datos frecuentemente solicitados.
5. **Message Broker**: RabbitMQ para la comunicaci�n eventual entre procesos internos.

---

## Funcionalidades

### M�dulo: Vehicles
- **Crear Veh�culo**: Registro de nuevos veh�culos en la flota.
- **Consultar Veh�culos**: Listado de veh�culos disponibles para alquiler.
- **Gestionar Categor�as**: Creaci�n y consulta de categor�as de veh�culos.

### M�dulo: Rentals
- **Crear Reserva**: Permite a los clientes reservar un veh�culo disponible.
- **Iniciar Alquiler**: Inicia el proceso de alquiler de un veh�culo.
- **Finalizar Alquiler**: Registra la devoluci�n del veh�culo y cierra el alquiler.

### M�dulo: Customers
- **Registrar Cliente**: Creaci�n de perfiles de clientes.
- **Consultar Clientes**: Obtener informaci�n de los clientes registrados.
- **Registrar Actividad**: Historial de interacciones y actividades de los clientes.

---

## Reglas de Negocio
1. Un veh�culo no puede ser alquilado si su antig�edad supera los 5 a�os desde su fecha de fabricaci�n.
2. Solo los veh�culos con estado `disponible` pueden ser reservados o alquilados.
3. Los clientes deben estar en estado `activo` para realizar reservas o alquileres.

---

## Arquitectura del Sistema

![Diagrama de Arquitectura](assets/ArchitectureDiagram.png)

