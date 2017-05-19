package org.ucu.PaDa.Task6.FT
import org.ucu.PaDa.Task6.Complex
import org.ucu.PaDa.Task6.Parallel._

/**
  * Created by Anatoliy on 15.05.2017.
  */
class ParallelFFT extends FFT {
  override def getEvenOdd(in: Array[Complex]) = {
    val N = in.length
    val halfIndices = (0 to N/2-1)

    parallel(transform(halfIndices.map(2*_).map(in(_)).toArray),
      transform(halfIndices.map(2*_+1).map(in(_)).toArray))
  }
}