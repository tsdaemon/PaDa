package org.ucu.PaDa.Task6

import java.io.File

import org.scalameter.api._
import org.ucu.PaDa.Task6.FT.{FFT, ParallelFFT, SunFFT}
import org.scalameter.picklers.Implicits._

object Benchmark extends Bench[Double] {

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
  lazy val persistor = JSONSerializationPersistor(new File("target/benchmarks/sun"))

   val sizes = Gen.exponential("Input size")(256, 1024*4, 2).cached

  val complexSequences = for (sz <- sizes) yield {
    println(sz)
    val real = (0 to (sz-1)).map(i => Math.cos(0.1*i)).toArray
    val imaginary = (0 to (sz-1)).map(i => Math.sin(0.1*i)).toArray
    real zip imaginary map {case (re, im) => Complex(re, im)}
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

  val sunFft = new SunFFT

  performance of "Java FFT implementation" in {
    measure method "transform" in {
      using(complexSequences) in { complex =>
        sunFft transform complex
      }
    }
  }
}