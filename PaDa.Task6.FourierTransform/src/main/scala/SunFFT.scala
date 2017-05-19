package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6.Complex2

/**
  * Created by Anatoliy on 19.05.2017.
  */
class SunFFT extends FFT {

  def complexToDouble(in: Array[Complex2]) = in.flatMap(c => List(c.re, c.im))

  def doubleToComplex(in: Array[Double]) = (0 to in.length/2-1)
    .map(i => Complex2(in(2*i), in(2*i+1))).toArray

  override def transform(in: Array[Complex2]): Array[Complex2] = {
    val sunFFT = new com.sun.media.sound.FFT(in.length, -1)
    val amplitudes = complexToDouble(in)
    sunFFT.transform(amplitudes)
    doubleToComplex(amplitudes)
  }

  override def transformDouble(in:Array[Double]):Array[Complex2] = {
    val sunFFT = new com.sun.media.sound.FFT(in.length, -1)

    val amplitudes = in.flatMap(List(_,0))
    sunFFT.transform(amplitudes)
    doubleToComplex(amplitudes)
  }
}
