# Laboratorio 1 - MesaTech: Gestor Dinámico de Tickets de Soporte Académico

## Curso
Estructura de Datos

## Caso práctico
MesaTech es un sistema de gestión de tickets de soporte académico implementado mediante una **lista enlazada simple**, que permite registrar, buscar, listar y eliminar tickets de forma dinámica, sin depender de un tamaño fijo de almacenamiento.

## Estructura de la solución

- **Clase `Nodo`**: representa cada ticket de la lista. Guarda `codigo`, `descripcion` y `prioridad` (todos `string`), además de una referencia `Sgte` al siguiente nodo (queda en `null` si es el último).
- **Clase `ListaEnlazadaTickets`**: administra la lista completa mediante dos referencias, `pri` (primer nodo) y `ulti` (último nodo), ambas iniciadas en `null` mientras la lista está vacía.

### Operaciones implementadas
- **Agregar**: crea un nodo nuevo; si la lista está vacía, se convierte en `pri` y `ulti` a la vez. Si ya hay nodos, se engancha al final (`ulti.Sgte` apunta al nuevo nodo y `ulti` se actualiza).
- **Buscar**: recorre la lista desde `pri` comparando el código ingresado; retorna si existe y muestra sus datos.
- **Eliminar**: recorre la lista guardando el nodo anterior. Si el nodo a eliminar es el primero, `pri` "salta" al siguiente; si tiene anterior, se conecta `anterior.Sgte` con `actual.Sgte`. También actualiza `ulti` si el nodo eliminado era el último.
- **Validación**: rechaza el registro de un código ya existente.

## Tecnologías usadas
- C# (Windows Forms)

## Pruebas funcionales
Se validaron los siguientes escenarios (todos con resultado exitoso):
- Listar lista vacía
- Agregar primer ticket y varios tickets en orden
- Buscar código existente e inexistente
- Eliminar el primer nodo, un nodo intermedio y un código inexistente
- Registrar código repetido (validación de dato inválido)

## Conclusiones
- Una lista enlazada simple es una estructura flexible para manejar datos que cambian constantemente (como el registro de tickets), ya que no depende de un tamaño fijo.
- Las pruebas confirmaron que el programa responde correctamente incluso en casos borde, como eliminar el primer nodo o intentar registrar un código repetido.
- Frente a un arreglo, la lista enlazada no permite acceso directo a una posición (hay que recorrerla nodo por nodo), pero sí permite insertar o eliminar en cualquier parte (inicio, medio o final), lo que la hace más adecuada para este caso de uso.