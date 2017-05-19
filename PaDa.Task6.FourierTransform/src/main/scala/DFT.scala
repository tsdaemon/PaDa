package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6._

/**
  * Created by Anatoliy on 15.05.2017.
  */
class DFT {
  def transform(x:Array[Complex2]):Array[Complex2] = {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
        .foldLeft[Complex2](Complex2(0,0))((res, n) => res + Complex2.create(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }

  def doubleAsComplex(in:Array[Double]) = in.map[Complex2, Array[Complex2]](Complex2(_,0))

  def transformDouble(x:Array[Double]):Array[Complex2] = //transform(doubleAsComplex(x))
  {
    val N = x.length

    (0 to (N-1))
      .map(k =>
        (0 to (N-1))
          .foldLeft[Complex2](Complex2(0,0))((res, n) => res + Complex2.create(1, -2*Math.PI*k*n/N)*x(n)))
      .toArray
  }
}