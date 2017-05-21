package org.ucu.PaDa.Task6

import math.{acos, cos, max, min, sin, signum}
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
/** This class is used to represent Complex numbers (a + bi) as (a, b), e.g.,
  *  (2.1, 3.2i).  Note: i * i = -1.
  *  @param re  the real part
  *  @param im  the imaginary part
  */
case class Complex (val re: Double, val im: Double = 0.0)
  extends Fractional [Complex] with Ordered [Complex]
{

  def unary_- () = Complex (-re, -im)
  def negate (c: Complex) = -c

  def + (c: Complex) = Complex (re + c.re, im + c.im)
  def plus (c: Complex, d: Complex) = c + d

  def + (r: Double) = Complex (re + r, im)
  def plus (c: Complex, r: Double) = c + r

  def - (c: Complex) = Complex (re - c.re, im - c.im)
  def minus (c: Complex, d: Complex) = c - d

  def - (r: Double) = Complex (re - r, im)
  def minus (c: Complex, r: Double) = c - r

  def * (c: Complex) = Complex (re * c.re - im * c.im, re * c.im + im * c.re)
  def times (c: Complex, d: Complex) = c * d

  def * (r: Double) = Complex (re * r, im * r)
  def times (c: Complex, r: Double) = c * r

  def / (c: Complex) = Complex ((re * c.re + im * c.im) / (c.re * c.re + c.im * c.im),
    (im * c.re - re * c.im) / (c.re * c.re + c.im * c.im))
  def div (c: Complex, d: Complex) = c / d

  def / (r: Double) = Complex ((re * r) / (r * r), (im * r) / (r * r))
  def div (c: Complex, r: Double) = c / r

  def ~^ (r: Double) = { val (rad, ang) = polar; Complex.create (Math.pow(rad,r), ang * r) }
  def pow (c: Complex, r: Double) = c ~^ r

  def radius: Double = math.sqrt (re *re + im *im)

  def angle: Double = acos (re / radius)

  def polar: Tuple2 [Double, Double] = { val rad = radius; (rad, acos (re / rad)) }

  def bar = Complex (re, -im)

  def abs = Complex (re.abs, im.abs)

  def max (c: Complex) = if (c > this) c else this

  def min (c: Complex) = if (c < this) c else this

  def isRe = im == 0.0

  def compare (c: Complex, d: Complex) =
  {
    if (c.re == d.re) c.im compare d.im else c.re compare d.re
  } // compare

  //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
  def compare (d: Complex) =
  {
    if (re == d.re) im compare d.im else re compare d.re
  } // compare

  def toDouble (c: Complex) = c.re
  def toDouble = re

  def toFloat (c: Complex) = c.re.toFloat
  def toFloat = re.toFloat

  def toInt (c: Complex) = c.re.toInt
  def toInt = re.toInt

  def toLong (c: Complex) = c.re.toLong
  def toLong = re.toLong

  def fromDouble (x: Double) = Complex (x)
  def fromFloat (x: Float) = Complex (x)
  def fromInt (n: Int) = Complex (n)
  def fromLong (n: Long) = Complex (n)

  override def equals (c: Any): Boolean =
  {
    c.isInstanceOf [Complex] && (re equals c.asInstanceOf [Complex].re) &&
      (im equals c.asInstanceOf [Complex].im)
  } // equals

  override def hashCode: Int = re.hashCode + 41 * im.hashCode

  override def toString = s"$re ${if(im>=0) "+" else "-"} ${Math.abs(im)}"

}

object Complex
{

  val _0  = Complex (0.0)

  val _1  = Complex (1.0)

  val _i  = Complex (0.0, 1.0)

  val _1n = Complex (-1.0)

  val _in = Complex (0.0, -1.0)

  private val rr2 = 1.0 / math.sqrt (2.0)   // reciprocal root of 2.

  def create (rad: Double, ang: Double): Complex = Complex (rad * cos (ang), rad * sin (ang))

  def abs (c: Complex): Complex = c.abs

  def sqrt (c: Complex): Complex =
  {
    val (a, b) = (c.re, c.im)
    val rad    = c.radius
    Complex (rr2 * math.sqrt (rad + a),
      rr2 * math.sqrt (rad - a) * signum (b))
  } // sqrt

  val ord = new Ordering [Complex]
  { def compare (x: Complex, y: Complex) = x compare y }

}
