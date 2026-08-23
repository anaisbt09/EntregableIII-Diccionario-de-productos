# Entregable III - Diccionario de Productos

## Funcionalidades

* Buscar un producto por ID
* Actualizar el stock de un producto
* Eliminar un producto
* Mostrar productos que tengan stock bajo
* Mostrar todos los productos
* Permitir al usuario salir de la aplicación.

---

## Estructura de datos utilizada

Para almacenar los productos se utilizó `Dictionary<int, Producto>`.

El diccionario utiliza una **clave** (`int`) para identificar cada producto y un **valor** (`Producto`) que contiene la información correspondiente.

Se utilizaron los siguientes métodos y propiedades:

* `Add()` para registrar productos en el diccionario.
* `TryGetValue()` para buscar un producto mediante su ID.
* `Remove()` para eliminar un producto.
* `Values` para recorrer los productos almacenados.
* `Count` para conocer la cantidad de productos registrados.

---

## Validaciones

* Valida que el ID ingresado sea un número entero.
* Verifica que el producto exista antes de buscarlo, actualizarlo o eliminarlo.
* No permite ingresar valores de stock negativos.
* Verifica si existen productos con stock bajo.
* Verifica si el inventario se encuentra vacío antes de mostrar los productos.
* Permite volver a ingresar los datos cuando existe un error.

---

## Autor

**Anais Milagros Bustamante Torres**
