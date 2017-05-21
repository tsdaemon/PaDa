package org.ucu.PaDa.Task6
/**
  * Created by Anatoliy on 13.03.2017.
  */

import org.scalatest.{FlatSpec, Matchers}
import org.ucu.PaDa.Task6.FT.{DFT, FFT, SunFFT}

class FFTSpec extends FlatSpec
  with Matchers{

  val real = (0 to 255).map(i => Math.cos(0.1*i)).toArray
  val imaginary = (0 to 255).map(i => Math.sin(0.1*i)).toArray
  val complex = real zip imaginary map {case (re, im) => Complex(re, im)}

  val fft = new FFT
  val sun_fft = new SunFFT
  val ERROR = 0.0001

  it should "transfrom complex correctly" in {
    val fft_result = fft transform complex
    val sun_fft_result = sun_fft transform complex

    val error = fft_result zip sun_fft_result map {case (fft, sun_fft) => (fft-sun_fft).radius > ERROR}

    all (error) should be (false)
  }

  it should "transfrom double correctly" in {
    val fft_result = fft transformDouble real
    //println(fft_result.mkString(" "))
    val sun_fft_result = sun_fft transformDouble real
    //println(sun_fft_result.mkString(" "))

    val error = fft_result zip sun_fft_result map {case (fft, sun_fft) => (fft-sun_fft).radius > ERROR}
    //val error = difference map(_>ERROR)

    all (error) should be (false)
  }
}