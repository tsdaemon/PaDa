name := "PaDa.Task6.FourierTransform"

version := "1.0"

scalaVersion := "2.11.8"

resolvers += "Sonatype OSS Snapshots" at
  "https://oss.sonatype.org/content/repositories/releases"

libraryDependencies ++= Seq(
  "org.scalatest" %% "scalatest" % "3.0.1" % "test",
  "org.scalacheck" %% "scalacheck" % "1.13.4" % "test",
  "com.storm-enroute" %% "scalameter" % "0.8.2" % "test" exclude("org.mongodb", "casbah_2.11")
)

testFrameworks += new TestFramework("org.scalameter.ScalaMeterFramework")

parallelExecution in Test := false

logBuffered := false