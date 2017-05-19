package org.ucu.PaDa.Task6
/**
  * Created by Anatoliy on 13.03.2017.
  */

import org.scalatest.{FlatSpec, Matchers}
import org.ucu.PaDa.Task6.FT.{DFT, FFT, SunFFT}

class FFTSpec extends FlatSpec
  with Matchers{

  val real = (0 to 63).map(0.1*_).map(Math.cos).toArray
  val imaginary = (0 to 63).map(0.1*_).map(Math.sin).toArray
  val complex = real.zip(imaginary).map(ri => ComplexCartesian(ri._1, ri._2)).toArray[Complex]
  val fft = new FFT
  val sun_fft = new SunFFT
  val ERROR = 0.01

  it should "transfrom complex correctly" in {
    val fft_result = fft transform complex
    val sun_fft_result = sun_fft transform complex

    val error = fft_result zip sun_fft_result map {case (dft, sun_fft) => dft.absDiffernce(sun_fft) > ERROR}

    all (error) should be (false)
  }

  it should "transfrom double correctly" in {
    val fft_result = fft transformDouble real
    println(fft_result.mkString(" "))
    val sun_fft_result = sun_fft transformDouble real
    println(sun_fft_result.mkString(" "))

    val difference = fft_result zip sun_fft_result map {case (dft, sun_fft) => dft.absDiffernce(sun_fft)}
    val error = difference map(_>ERROR)

    all (error) should be (false)
  }
}