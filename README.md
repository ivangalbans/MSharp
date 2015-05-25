M# Language
===============

PLOTTER
-------

Los matemáticos se han cansado de graficar funciones a mano y han pedido la colaboración de los programadorespara que diseñen e implementen un ambiente de desarrollo en el que puedan escribir sus fórmulas y visualizar sus funciones. La aplicación deberá tener áreas para la edición de código, la consola de entrada y salida, y un área en que se visualicen los gráficos de las funciones.
El diseño de clases debe ser suficientemente flexible para incorporar nuevas funciones, instrucciones, operadores y tipos de expresiones en un futuro.

EL LENGUAJE M# (M DE MATEMÁTICA)
--------------------------------

El lenguaje M# tiene una sintaxis simple con la cual un programa se representa como un conjunto de instrucciones para declarar, leer, imprimir o terminar la ejecución. Las variables son de un único tipo “numérico” aunque existen expresiones condicionales y texto.

LITERALES
---------

Como en C# los literales permiten expresar valores que son prefijados en el código. Por ejemplo: 5, -4, 3.141596, “Hola”. Para el caso numérico el tipo del literal siempre es number, a diferencia de en C# en el que 5 es un literal de tipo int y 5.0 un literal de tipo double. Los textos encerrados entre comillas dobles (i.e. “Entre un número”) son literales de tipo string.

VARIABLES
---------

Los nombres de las variables pueden estar formados por letras y números siempre empezando en letra. Por ejemplo:
a, a1, miVariable, mi2daVariable.
Para declarar una variable se utiliza la instrucción let. Para asignar un valor a una variable se escribe:

~~~fsharp
let <var> = <expresión>
~~~

Ejemplos:

~~~fsharp
let a = 4
let x1 = 3+a
let y=f(4)*2+1.
~~~

Para declarar una variable no se necesita especificar de qué tipo es porque siempre será de tipo number. No sepuede declarar una variable sin asignarle un valor y no se puede utilizar una variable sin haberla declarado con anterioridad. Si la variable ya está definida la nueva declaración produce un error. Ejemplo:

~~~fsharp
let a = 4
…
let a = 1000 (<< Error!)
~~~

No obstante con la instrucción de asignación (set) se puede cambia el valor:

~~~python
set a = 1000
print a (aquí se imprime 1000)
~~~

OPERADORES
----------

Se deben permitir los operadores comúnmente utilizados en el álgebra, como son: suma (+), resta (-), multiplicación (*), división (/), modulo (%), potencia (^), negación (-), positivo (+), negación lógica (!), el “y” lógico (&), y el “o” lógico (|). Además existen algunos operadores de comparación que evalúan tipo boolean.
Algunos operadores tienen cierta prioridad de evaluación sobre otros. Por ejemplo, la multiplicación deberá
realizarse siempre antes que la suma. El orden de evaluación de los operadores básicos que usted deberá soportar en su lenguaje aparece en la Tabla 1. Los operadores que están dentro del mismo bloque tienen igual prioridad y se evalúan dependiendo del orden en que aparecen.

Operadores y sus prioridades
----------------------------

1. () Agrupadores para expresiones.

	Ejemplo:
	~~~fsharp
	5*((2+x)/2)
	~~~

2. ‘ Derivación

3. ^ Potencia.
	
	Ejemplo:
	~~~fsharp
	4^2 (4 al cuadrado)
	~~~

4. * / Multiplicación y división binaria
5. + - Operadores unarios de positivo o negativo.
	
	Ejemplo:
	~~~fsharp
	-3+5
	2-+2
	~~~

6. +, - Operadores binarios de suma o resta.

	Ejemplo:
	~~~fsharp
	3+4-5
	~~~

7. <, <=, >, >=, !=, ==	Operadores de comparación

	Ejemplo:
	~~~fsharp
	x<4
	y>=x+5
	x!=3
	~~~

8. & Operador lógico and.

	Ejemplo:
	~~~fsharp
	-2<x & x<=4
	~~~

9. | Operador lógico or.

	Ejemplo:
	~~~fsharp
	x <=-4 | x > 5
	~~~fsharp

10. if else Operador condicional (<exp1> if <condicional> else <exp2>)
	
	Ejemplo:
	~~~python
	def sign (x) = 1 if x > 0 else -1 if x < 0 else 0
	~~~

Los operadores aritméticos (+, -, *, /, %, ^) operan sobre expresiones numéricas y devuelven un valor numérico. Los de comparación operan sobre valores numéricos y devuelven un valor booleano. Los lógicos operan sobre valores booleanos y devuelven un valor booleano.

FUNCIONES
---------

Como se ha ilustrado, el programa permite definir y evaluar funciones. Existen un conjunto de funciones predefinidas y que no pueden ser “redefinidas”. Tal es el caso de las funciones: sin, cos, tan, atan, cot, arcsin, arccos, exp, ln, abs, que usted deberá implementar como parte de su aplicación. Las funciones homónimas del tipo System.Math permiten saber los argumentos que reciben estas
funciones y lo que devuelven. Todas las funciones son de R->R, tanto las predefinidas en el lenguaje como las definidas por el usuario.
Para definir una función propia del usuario este debe utilizar la instrucción def. La sintaxis es:

	def <función> ( <parámetro> ) = <expresión>

Ejemplos:
~~~python
	def f ( x ) = x * 4 + 1
	def g ( a ) = a * (a + 1)
~~~

GRAFICANDO
----------

Su aplicación deberá permitir visualizar funciones. Para ello se utilizará la instrucción graph. Esta instrucción está precedida de una expresión que tiene por defecto un parámetro con nombre x que es la variable libre que se evaluará (valores del eje x).

Ejemplo:

~~~python
def f(x) = x * sin (x)
graph f(x)
~~~

Es equivalente a:

~~~python
graph x * sin (x)
~~~

Note que la instrucción:

	graph 4

Es válida y visualiza la función constante f(x)=4

DERIVADAS
---------

En cualquier expresión en un contexto donde exista un parámetro se puede utilizar el operador derivada (’). Este operador resuelve la derivada con respecto al parámetro. Este operador tiene mayor prioridad que los expuestos anteriormente. Note que hasta el momento los lugares donde existen parámetros son el cuerpo de una función (el parámetro de la función) o la expresión del comando graph (el parámetro especial x).

Ejemplos:

~~~fsharp
def f(x)=sin(x)’ + cos(x)
def g(x)=f(x)’’ // Las derivadas segundas se obtienen de aplicar derivada a una derivada.
graph (x^2+2*x+1)’ // Se puede aplicar derivada en esta expresión porque existe el parámetro especial x.
~~~

CONTEXTOS
---------

En M# existen sólo dos contextos, global y local. El contexto global es en el que se definen las funciones y las variables. El contexto local es el cuerpo de las funciones o de la instrucción graph. Si una variable tiene igual nombre que un parámetro, se tomará el valor del parámetro en lugar del de la variable global. 

Ejemplo:

~~~
let x = 5
def f (x) = x << esta x se refiere al parámetro y no a la variable global
~~~

ENTRADA Y SALIDA
La aplicación tiene una consola que permite mostrar y recibir valores del usuario. Para ello se utilizan las instrucciones print y read.
La instrucción print recibe la expresión cuyo valor será mostrado en la salida. La instrucción read recibe la variable en la que almacenará el valor introducido por el usuario. La entrada siempre será un número.

Ejemplo:
~~~python
let n = 0
print “Entre el valor de n”
read n
def f(x)=x + n
~~~

MÓDULOS
-------

Cada código editado se almacenará en un fichero con extensión .mat. Este código representa un módulo. Desde un módulo se puede “invocar” la ejecución de otro módulo con la instrucción include “<modulo>”.
Suponga que existe un fichero en el mismo directorio de trabajo que el módulo actual con una lógica como se muestra:

MÓDULO “FUNCIONPARAMETRIZADA.MAT”

~~~python
let n = 0
let m = 1
f ( x ) = m * x + n
~~~

En el módulo actual se puede incluir estas definiciones de la forma.

MÓDULO “MI NUEVO PROGRAMA.MAT”

~~~python
include “FuncionParametrizada”
set n = 1
set m = 2
print f ( 4 ) // << imprime 9
~~~

Note que en el punto en que se asigna 1 a la variable n ya se definió con anterioridad al incluir el otro módulo. Se debe detectar dependencias cíclicas entre los módulos y producir un error en consecuencia. Si al incluir un módulo se incurre en la re-declaración de una variable o función debe producirse un error.

SOBRE EL DISEÑO DE CLASES
-------------------------

Para definir el conjunto de tipos que le permitan modelar esta aplicación tenga en cuenta lo siguiente:

1. No vincular los tipos que permiten modelar el concepto de expresión, los mecanismos de evaluarla, las funciones, las instrucciones y demás, con la aplicación final que Usted propone. Piense que todo el esfuerzo que usted realice para resolver esas tareas debe ser fácilmente aprovechable para crear otras aplicaciones distintas a la suya. Ejemplo: una aplicación de consola, una aplicación web.

2. Debe ser posible incorporar nuevos operadores y funciones predefinidas a su proyecto. Al punto de poder escribir: Operadores.Add (new OperadorÑañarita ()) y una vez compilado nuevamente su proyecto el operador agregado pueda ser utilizado.

Autor
-----

Iván Galbán Smith <ivan.galban.smith@gmail.com>

Estudiante de 1er año de Ciencia de la Computación

Universidad de La Habana, 2015