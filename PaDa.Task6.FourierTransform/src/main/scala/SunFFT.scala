package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6.{Complex, ComplexCartesian}

/**
  * Created by Anatoliy on 19.05.2017.
  */
class SunFFT extends FFT {

  def complexToDouble(in: Array[Complex]) = in.flatMap(c => List(c.real, c.imaginary))

  def doubleToComplex(in: Array[Double]) = (0 to in.length/2-1)
    .map(i => ComplexCartesian(in(2*i), in(2*i+1))).toArray[Complex]

  override def transform(in: Array[Complex]): Array[Complex] = {
    val sunFFT = new com.sun.media.sound.FFT(in.length, -1)
    val amplitudes = complexToDouble(in)
    sunFFT.transform(amplitudes)
    doubleToComplex(amplitudes)
  }

  override def transformDouble(in:Array[Double]):Array[Complex] = {
    val sunFFT = new com.sun.media.sound.FFT(in.length, -1)

    val amplitudes = in.flatMap(List(_,0))
    sunFFT.transform(amplitudes)
    doubleToComplex(amplitudes)
  }
}
