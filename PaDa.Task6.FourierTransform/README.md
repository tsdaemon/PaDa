## Parallel fast Fourier transform

To test this implementation I've compared my FFT and parallel FFT with my naive $O(n^2)$ 
DFT implementation and standard FFT implementation from JDK: `com.sun.media.sound.FFT`. Parallel FFT with Scala `ForkJoinPool` has shown 
good advance in performance in comparison with sequential FFT. But they still can not overcome (not surprisingly) Sun implementation.

Here is the reports from [ScalaMeter](http://scalameter.github.io):

