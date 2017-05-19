import org.ucu.PaDa.Task6.FT._
import org.ucu.PaDa.Task6._

var real = Array(10.0, 0.0, 2.0, 0.0)
var imaginary = Array(1.0,2.0,3.0,4.0)
var complex = real.zip(imaginary).map(ri => Complex2(ri._1, ri._2))

val dft = new DFT
val fft = new FFT
var fft_p = new ParallelFFT
val sun_fft = new SunFFT
val ERROR = 0.001

dft transform complex
fft transform complex
fft_p transform complex
sun_fft transform complex

dft transformDouble real
fft transformDouble real
fft_p transformDouble real
sun_fft transformDouble real


real = (0 to 63).map(i => Math.cos(0.1*i)).toArray
imaginary = (0 to 63).map(i => Math.sin(0.1*i)).toArray
complex = real.zip(imaginary).map(ri => Complex2(ri._1, ri._2)).toArray

dft transform complex
fft transform complex
fft_p transform complex
sun_fft transform complex

dft transformDouble real
fft transformDouble real
fft_p transformDouble real
sun_fft transformDouble real

real = Array(10.0, 1.0)
imaginary = Array(1.0, 2.0)
complex = real.zip(imaginary).map(ri => Complex2(ri._1, ri._2))

dft transform complex
fft transform complex
fft_p transform complex
sun_fft transform complex