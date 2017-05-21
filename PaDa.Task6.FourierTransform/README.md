## Parallel fast Fourier transform

To test this implementation I've compared my FFT and parallel FFT with my naive $O(n^2)$ 
DFT implementation and standard FFT implementation from JDK: `com.sun.media.sound.FFT`. Parallel FFT with Scala `ForkJoinPool` has shown 
good advance in performance in comparison with sequential FFT. But they still can not overcome (not surprisingly) Sun implementation.

Here is the reports from [ScalaMeter](http://scalameter.github.io):

[With DFT](http://htmlpreview.github.io/?https://github.com/tsdaemon/PaDa/blob/master/PaDa.Task6.FourierTransform/report/with_dft/index.html)

[With Java FFT](http://htmlpreview.github.io/?https://github.com/tsdaemon/PaDa/blob/master/PaDa.Task6.FourierTransform/report/with_fft/index.html)