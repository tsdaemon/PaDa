package org.ucu.PaDa.Task6

import java.io.File

import org.scalameter.api._
import org.ucu.PaDa.Task6.FT.{DFT, FFT, ParallelFFT}
import org.scalameter.picklers.Implicits._

object BenchmarkWithDFT extends Bench[Double] {

  lazy val executor = SeparateJvmsExecutor(
    Executor.Warmer.Zero,
    Aggregator.average,
    measurer)

  lazy val measurer = new Measurer.Default
  lazy val reporter = Reporter.Composite(
    new RegressionReporter[Double](
      RegressionReporter.Tester.ConfidenceIntervals(),
      RegressionReporter.Historian.Complete()),
    HtmlReporter[Double](true)
  )
  lazy val persistor = JSONSerializationPersistor(new File("target/benchmarks/dft"))

  val sizes = Gen.exponential("Input size")(128, 1024*2, 2).cached

  val complexSequences = for (sz <- sizes) yield {
    val real = (0 to (sz-1)).map(i => Math.cos(0.1*i)).toArray
    val imaginary = (0 to (sz-1)).map(i => Math.sin(0.1*i)).toArray
    real zip imaginary map {case (re, im) => Complex(re, im)}
  }

  val dft = new DFT

  performance of "DFT" in {
    measure method "transform" in {
      using(complexSequences) in { complex =>
        dft transform complex
      }
    }
  }

  val fft = new FFT

  performance of "FFT" in {
    measure method "transform" in {
      using(complexSequences) in { complex =>
        fft transform complex
      }
    }
  }

  val parallelFft = new ParallelFFT

  performance of "Parallel FFT" in {
    measure method "transform" in {
      using(complexSequences) in { complex =>
        parallelFft transform complex
      }
    }
  }
}