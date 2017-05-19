import org.ucu.PaDa.Task6.{ComplexCartesian, _}

ComplexPolar(1, -2*Math.PI*1*1/64)*1

ComplexCartesian(1,0)*ComplexPolar(1, -2*Math.PI*1*1/64)

var real = (0 to 63).map(i => Math.cos(0.1*i)).toArray
var imaginary = (0 to 63).map(i => Math.sin(0.1*i)).toArray
//var complex = real.zip(imaginary).map(ri => ComplexCartesian(ri._1, ri._2)).toArray[Complex]
var complex =  real.map[Complex, Array[Complex]](ComplexCartesian(_,0))



var N = real.length

(0 to (N-1))
  .map(k =>
    (0 to (N-1))
      .foldLeft[Complex](ComplexCartesian(0,0))((res, n) => {
      //println(res + ComplexPolar(1, -2*Math.PI*k*n/N)*real(n))
      res + ComplexPolar(1, -2*Math.PI*k*n/N)*real(n)
    }))
  .toArray

(0 to (N-1))
  .map(k =>
    (0 to (N-1))
      .foldLeft[Complex](ComplexCartesian(0,0))((res, n) => {
      //println(res + ComplexPolar(1, -2*Math.PI*k*n/N)*complex(n))
      res + ComplexPolar(1, -2*Math.PI*k*n/N)*complex(n)
    }))
  .toArray