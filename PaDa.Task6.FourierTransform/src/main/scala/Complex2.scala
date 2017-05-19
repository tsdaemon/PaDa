package org.ucu.PaDa.Task6

import math.{acos, cos, max, min, sin, signum}
//:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
/** This class is used to represent Complex2 numbers (a + bi) as (a, b), e.g.,
  *  (2.1, 3.2i).  Note: i * i = -1.
  *  @param re  the real part
  *  @param im  the imaginary part
  */
case class Complex2 (val re: Double, val im: Double = 0.0)
  extends Fractional [Complex2] with Ordered [Complex2]
{

  def unary_- () = Complex2 (-re, -im)
  def negate (c: Complex2) = -c

  def + (c: Complex2) = Complex2 (re + c.re, im + c.im)
  def plus (c: Complex2, d: Complex2) = c + d

  def + (r: Double) = Complex2 (re + r, im)
  def plus (c: Complex2, r: Double) = c + r

  def - (c: Complex2) = Complex2 (re - c.re, im - c.im)
  def minus (c: Complex2, d: Complex2) = c - d

  def - (r: Double) = Complex2 (re - r, im)
  def minus (c: Complex2, r: Double) = c - r

  def * (c: Complex2) = Complex2 (re * c.re - im * c.im, re * c.im + im * c.re)
  def times (c: Complex2, d: Complex2) = c * d

  def * (r: Double) = Complex2 (re * r, im * r)
  def times (c: Complex2, r: Double) = c * r

  def / (c: Complex2) = Complex2 ((re * c.re + im * c.im) / (c.re * c.re + c.im * c.im),
    (im * c.re - re * c.im) / (c.re * c.re + c.im * c.im))
  def div (c: Complex2, d: Complex2) = c / d

  def / (r: Double) = Complex2 ((re * r) / (r * r), (im * r) / (r * r))
  def div (c: Complex2, r: Double) = c / r

  def ~^ (r: Double) = { val (rad, ang) = polar; Complex2.create (Math.pow(rad,r), ang * r) }
  def pow (c: Complex2, r: Double) = c ~^ r

  def radius: Double = math.sqrt (re *re + im *im)

  def angle: Double = acos (re / radius)

  def polar: Tuple2 [Double, Double] = { val rad = radius; (rad, acos (re / rad)) }

  def bar = Complex2 (re, -im)

  def abs = Complex2 (re.abs, im.abs)

  def max (c: Complex2) = if (c > this) c else this

  def min (c: Complex2) = if (c < this) c else this

  def isRe = im == 0.0

  def compare (c: Complex2, d: Complex2) =
  {
    if (c.re == d.re) c.im compare d.im else c.re compare d.re
  } // compare

  //:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
  def compare (d: Complex2) =
  {
    if (re == d.re) im compare d.im else re compare d.re
  } // compare

  def toDouble (c: Complex2) = c.re
  def toDouble = re

  def toFloat (c: Complex2) = c.re.toFloat
  def toFloat = re.toFloat

  def toInt (c: Complex2) = c.re.toInt
  def toInt = re.toInt

  def toLong (c: Complex2) = c.re.toLong
  def toLong = re.toLong

  def fromDouble (x: Double) = Complex2 (x)
  def fromFloat (x: Float) = Complex2 (x)
  def fromInt (n: Int) = Complex2 (n)
  def fromLong (n: Long) = Complex2 (n)

  override def equals (c: Any): Boolean =
  {
    c.isInstanceOf [Complex2] && (re equals c.asInstanceOf [Complex2].re) &&
      (im equals c.asInstanceOf [Complex2].im)
  } // equals

  override def hashCode: Int = re.hashCode + 41 * im.hashCode

  override def toString = s"$re ${if(im>=0) "+" else "-"} ${Math.abs(im)}"

}

object Complex2
{

  val _0  = Complex2 (0.0)

  val _1  = Complex2 (1.0)

  val _i  = Complex2 (0.0, 1.0)

  val _1n = Complex2 (-1.0)

  val _in = Complex2 (0.0, -1.0)

  private val rr2 = 1.0 / math.sqrt (2.0)   // reciprocal root of 2.

  def create (rad: Double, ang: Double): Complex2 = Complex2 (rad * cos (ang), rad * sin (ang))

  def abs (c: Complex2): Complex2 = c.abs

  def sqrt (c: Complex2): Complex2 =
  {
    val (a, b) = (c.re, c.im)
    val rad    = c.radius
    Complex2 (rr2 * math.sqrt (rad + a),
      rr2 * math.sqrt (rad - a) * signum (b))
  } // sqrt

  val ord = new Ordering [Complex2]
  { def compare (x: Complex2, y: Complex2) = x compare y }

}
