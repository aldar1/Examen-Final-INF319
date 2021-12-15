import scala.collection.mutable.ListBuffer

def fibo4(n: Int): Int = {
  n match {
    case 0 | 1 | 2 => 0
    case 3 => 1
    case _ => fibo4(n - 1) + fibo4(n - 2) + fibo4(n - 3) + fibo4(n - 4)
  }
}
def fibonacci4(n: Int): IndexedSeq[Int] = {
  for (i <- 0 until n) yield fibo4(i)
}

def fib1( n : Int) : Int = n match {
   case 0 | 1 => n
   case _ => fib1( n-1 ) + fib1( n-2 )
}

def calculadora(operacion: String): (Int, Int) => Int = {
  operacion match {
    case "suma" => (x: Int, y: Int) => x + y
    case "resta" => (x: Int, y: Int) => x - y
    case "multiplicacion" => (x: Int, y: Int) => x * y
    case "division" => (x: Int, y: Int) => x / y
  }
}

def esPrimo(n: Int): Boolean = {
  for (i <- 2 until n - 1) {
    if (n % i == 0) {
      return false
    }
  }
  true
}

def primos(n: Int) = {
  (2 to n).foreach(i => if (esPrimo(i)) print(i + " "))
}

def primos2(n: Int): ListBuffer[Int] = {
  val lista: ListBuffer[Int] = ListBuffer()
  var numero = 2
  var limite = 0
  while (limite < n) {
    if (esPrimo(numero)) {
      lista += numero
      limite += 1
    }
    numero += 1
  }
  lista
}

def sumaMatriz(ma: Array[Array[Int]], mb: Array[Array[Int]]): Array[Array[Int]] = {
  var mc = Array.ofDim[Int](2, 2)
  for (i <- 0 until ma.length) {
    for (j <- 0 until ma(0).length) {
      mc(i)(j) = ma(i)(j) + mb(i)(j)
    }
  }
  mc
}


def restaMatriz(ma: Array[Array[Int]], mb: Array[Array[Int]]): Array[Array[Int]] = {
  var mc = Array.ofDim[Int](2, 2)
  for (i <- 0 until ma.length) {
    for (j <- 0 until ma(0).length) {
      mc(i)(j) = ma(i)(j) - mb(i)(j)
    }
  }
  mc
}

def calculadoraMatriz(operacion: String): (Array[Array[Int]], Array[Array[Int]]) => Array[Array[Int]] = {
  operacion match {
    case "suma" => sumaMatriz
    case "resta" => restaMatriz
  }
}

def detMatriz(ma: Array[Array[Int]]): Int = ma(0)(0) * ma(1)(1) + ma(0)(1) * ma(1)(0)

def cofMatriz(ma: Array[Array[Int]]): Array[Array[Int]] = {
  Array(Array(ma(1)(1), -ma(1)(0)), Array(-ma(0)(1), ma(0)(0)))
}
def invMatriz(ma: Array[Array[Int]]): Array[Array[Double]] = {
  Array(cofMatriz(ma)(0).map(_ / detMatriz(ma)), cofMatriz(ma)(1).map(_ / detMatriz(ma)))
}

def printMatrix(ma: Array[Array[Int]]) = {
  var i = 0;
  while (i < 2) {
    var j = 0;
    while (j < 2) {
      printf("%d\t", ma(i)(j))
      j = j + 1;
    }
    i = i + 1
    println()
  }
}
def imprimeMatriz(ma: Array[Array[Int]]) = {
  for (i <- ma) (for (x <- 0 until i.length) print(i(x) + " "))
}




// 1. Fibonacci de 4 numeros
print("1. Fibonacci de 4 numeros")
for (i <- fibonacci4(10)) print(i + "  ")

// 2. Calculadora de orden superior
val a = 1
val b = 2

print("2. Calculadora de Orden Superior")
print(s"$a + $b = " + calculadora("suma")(a, b))
print(s"$a - $b = " + calculadora("resta")(a, b))
print(s"$a * $b = " + calculadora("multiplicacion")(a, b))
print(s"$a / $b = " + calculadora("division")(a, b))

// 3. Calculadora de Matrices de orden superior
print("3. Calculadora de Matrices de orden superior")

var ma = Array(Array[Int](1, 2), Array[Int](3, 4))
var mb = Array(Array[Int](5, 6), Array[Int](7, 8))

printMatrix(ma)
print("+")
printMatrix(mb)
print("=")
printMatrix(calculadoraMatriz("suma")(ma, mb))
print("\n-----------------------------------\n")
printMatrix(ma)
print("-")
printMatrix(mb)
print("=")
printMatrix(calculadoraMatriz("resta")(ma, mb))


// 4. Generador de numeros primos
print("4. Generador de numeros primos")
primos(545)
for (i <- primos2(100).toList) print(i + " ")


