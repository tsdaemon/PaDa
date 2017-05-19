package org.ucu.PaDa.Task6
import org.scalacheck.Prop.forAll
import org.scalacheck.{Gen, Properties}

object ComplexCartesianSpecification extends Properties("ComplexCartesian") {
  val complexValues: Gen[ComplexCartesian] =
    for {
      i <- Gen.choose(-100, 100)
      r <- Gen.choose(-100, 100)
    } yield new ComplexCartesian(i, r)

  property("modulus") = forAll(complexValues) { c: ComplexCartesian => c.modulus.equals(math.sqrt(c.re*c.re + c.im*c.im)) }

  property("argument") = forAll(complexValues) { c: ComplexCartesian =>
    if(c.re != 0) c.argument.equals(math.atan(c.im/c.re))
    else c.argument.equals(0)
  }
}

object ComplexPolarSpecification extends Properties("ComplexCartesian") {
  val complexValues: Gen[ComplexPolar] =
    for {
      m <- Gen.choose(-100, 100)
      a <- Gen.choose(-Math.PI, Math.PI)
    } yield new ComplexPolar(m, a)

  property("real") = forAll(complexValues) { c: ComplexPolar => c.real.equals(c.m*math.cos(c.arg)) }

  property("imaginary") = forAll(complexValues) { c: ComplexPolar => c.imaginary.equals(c.m*math.sin(c.arg)) }
}

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