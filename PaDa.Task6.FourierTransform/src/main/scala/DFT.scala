package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6.{Complex, ComplexCartesian, ComplexPolar}

/**
  * Created by Anatoliy on 15.05.2017.
  */
class DFT {
  def transform(x:Array[Complex]):Array[Complex] = {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
        .foldLeft[Complex](ComplexCartesian(0,0))((res, n) => res + ComplexPolar(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }

  def doubleAsComplex(in:Array[Double]) = in.map[Complex, Array[Complex]](ComplexCartesian(_,0))

  def transformDouble(x:Array[Double]):Array[Complex] = //transform(doubleAsComplex(x))
  {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
          .foldLeft[Complex](ComplexCartesian(0,0))((res, n) => res + ComplexPolar(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }
}