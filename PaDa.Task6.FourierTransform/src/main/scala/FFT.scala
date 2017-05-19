package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6.{Complex, ComplexCartesian, ComplexPolar}
/**
  * Created by Anatoliy on 15.05.2017.
  */
class FFT extends DFT {
  override def transform(in:Array[Complex]):Array[Complex] = {
    val N = in.length

    if(N==1) in
    else {
      val (even, odd) = getEvenOdd(in)

      (even.indices.map(j => even(j) + odd(j)*ComplexPolar(1, 2*Math.PI*j/N)) ++
        even.indices.map(j => even(j) - odd(j)*ComplexPolar(1, 2*Math.PI*j/N))).toArray
    }
  }

  override def transformDouble(in:Array[Double]):Array[Complex] = {
    transform(doubleAsComplex(in))
  }

  def getEvenOdd(in:Array[Complex]) = {
    val N = in.length
    val halfIndices = (0 to N/2-1)

    (transform(halfIndices.map(2*_).map(in(_)).toArray), transform(halfIndices.map(2*_+1).map(in(_)).toArray))
  }
}