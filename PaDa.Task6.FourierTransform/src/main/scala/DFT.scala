package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6._

/**
  * Created by Anatoliy on 15.05.2017.
  */
class DFT {
  def transform(x:Array[Complex]):Array[Complex] = {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
        .foldLeft[Complex](Complex(0,0))((res, n) => res + Complex.create(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }

  def doubleAsComplex(in:Array[Double]) = in.map[Complex, Array[Complex]](Complex(_,0))

  def transformDouble(x:Array[Double]):Array[Complex] = //transform(doubleAsComplex(x))
  {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
          .foldLeft[Complex](Complex(0,0))((res, n) => res + Complex.create(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }
}