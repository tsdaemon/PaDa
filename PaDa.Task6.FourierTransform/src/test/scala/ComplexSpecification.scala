package org.ucu.PaDa.Task6
import org.scalacheck.Prop.forAll
import org.scalacheck.{Gen, Properties}

object ComplexSpecification extends Properties("Complex") {
  val complexCartValues: Gen[Complex] =
    for {
      i <- Gen.choose(-100, 100)
      r <- Gen.choose(-100, 100)
    } yield new ComplexCartesian(i, r)

  val complexPolarValues: Gen[Complex] = for {
      mod <- Gen.choose(-100, 100)
      arg <- Gen.choose(-100, 100)
    } yield new ComplexPolar(mod, arg)

  property("sum adds real parts") = forAll(complexCartValues,complexPolarValues) {
    (c1: Complex, c2:Complex) => (c1+c2).real.equals(c1.real + c2.real)
  }

  property("sum adds imaginary parts") = forAll(complexCartValues,complexPolarValues) {
    (c1: Complex, c2:Complex) => (c1+c2).imaginary.equals(c1.imaginary + c2.imaginary)
  }

  property("product muls modulus") = forAll(complexCartValues,complexPolarValues) {
    (c1: Complex, c2:Complex) => (c1*c2).modulus.equals(c1.modulus*c2.modulus)
  }

  property("product adds argument") = forAll(complexCartValues,complexPolarValues) {
    (c1: Complex, c2:Complex) => (c1*c2).argument.equals(c1.argument + c2.argument)
  }
}