package org.ucu.PaDa.Task6

sealed trait Complex {
  def real:Double
  def imaginary:Double
  def modulus:Double
  def argument:Double

  def +(that: Complex):Complex = ComplexCartesian(this.real + that.real, this.imaginary + that.imaginary)
  def +(that: Double):Complex = this+ComplexCartesian(that, 0)

  def -(that: Complex):Complex = ComplexCartesian(this.real - that.real, this.imaginary - that.imaginary)
  def -(that: Double):Complex = this-ComplexCartesian(that, 0)

  def *(that:Complex) = ComplexPolar(that.modulus*this.modulus, that.argument+this.argument)
  def *(that:Double):Complex = this*ComplexCartesian(that, 0)

  def /(that:Complex) = ComplexPolar(this.modulus/that.modulus, this.argument-that.argument)
  def /(that:Double):Complex = this/ComplexCartesian(that, 0)

  override def equals(any: scala.Any): Boolean = any match {
    case ComplexCartesian(re, im) => re == real && im == imaginary
    case ComplexPolar(mod, arg) => modulus == mod && argument == arg
    case d:Double => d == real && imaginary == 0
    case _ => false
  }

  def absDiffernce(that: Complex): Double = (this-that).modulus

  //override def toString: String = s"${modulus}e^(i${argument})"
  override def toString: String = s"${real} ${if(imaginary>0)"+" else "-"} ${Math.abs(imaginary)}i"
  //override def toString: String = s"${real}"
}

case class ComplexCartesian(re: Double, im:Double) extends Complex {
  override def real: Double = re

  override def imaginary: Double = im

  override def modulus: Double = Math.sqrt(Math.pow(re,2) + Math.pow(im,2))

  override def argument: Double = if(re == 0) 0 else if (im == 0 && re < 0) Math.PI else Math.atan(im/re)
}

case class ComplexPolar(m: Double, arg:Double) extends Complex {
  override def real: Double = m*Math.cos(arg)

  override def imaginary: Double = m*Math.sin(arg)

  override def modulus: Double = m

  override def argument: Double = arg
}