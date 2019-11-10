---
title: 'A model-view-viewModel (MVVM) application framework for hearing impairment diagnosis'
tags:
  - C#
  - WPF
  - audiometry
  - hearing loss
  - model-view-viewmodel
authors:
  - name: Waseem Sheikh
    orcid: 0000-0002-4647-4565
    affiliation: 1
  - name: Nadeem Sheikh
    affiliation: 2
affiliations:
 - name: Associate Professor, Oregon Institute of Technology, USA
   index: 1
 - name: Assistant Professor of ENT, CMH, Abbottabad, Pakistan
   index: 2
date: 9 Nov 2019
bibliography: paper.bib
---

# Summary

Around 466 million people worldwide (over 5% of the world's population) have disabling hearing loss, and out of these 34 million are children. Estimates suggest that by 2050, over 900 million people worldwide will have disabling hearing loss. The annual global cost of unaddressed hearing loss amounts to US$ 750 billion. Early detection of hearing loss can reduce its impact on an individual's life in addition to saving a huge cost. Even though proprietary hearing test software applications exist from various vendors, their price makes these prohibitive for underdeveloped countries which tend to have a higher prevalence of people with hearing loss. In most underdeveloped countries, hearing test data is stored on paper and graphs such as audiograms are drawn by hand. Such a system of managing hearing test data is error-prone and makes it very difficult to save, track, analyze, and reproduce hearing test data. In addition, a lack of open-source software in this domain stifles innovation.

Audiometry is an open-source application framework written in C# and based on WPF and .NET to create hearing test applications. Audiometry enables accurate digital recording, search, analysis, graphical visualization, and reproduction of human audio-vestibular impairment test data to assist in hearing loss or disability diagnosis. The framework is built using the Model-View-ViewModel (MVVM) software architectural pattern which separates the development of graphical user interface (GUI) from the development of business and back-end logic. Some of the benefits of the MVVM pattern include reusable components, independent development of GUI and business or back-end logic, flexibility to modify GUI without having to change business or back-end logic, ease of comprehensive unit testing, faster application development time, and reduced maintenance overhead. The proposed framework makes it possible to easily extend the application functionality thus enabling other researchers and practitioners to develop their own hearing impairment diagnosis applications.

Audiometry can store, search, analyze, print, and visualize data corresponding to tuning fork tests including Weber, Rinne, Schwabach, absolute bone conduction, Teal, and Gelle; speech audiometry; pure-tone audiometry (PTA); impedance audiometry; bithermal caloric test; and advanced tests including alternate binaural loudness balance (ABLB), short increment sensitivity index (SISI), tone decay, and Stenger. The application framework can also be used to develop new hearing test applications by extending its current functionality. Audiometry is independent of specific hearing test hardware thus making it possible to be used with a wide variety of hearing test hardware. In addition, Audiometry provides a unified and uniform interface for storing, analyzing, and visualizing data from a wide range of hearing tests which traditionally rely on different hardware and software. The software was evaluated by an otolaryngologist who found it to be very beneficial in reaching a hearing impairment diagnosis conclusion more methodically, swiftly, and accurately.

The current functionality of the application can be extended and enhanced in various ways. Some important future research directions include adding additional hearing impairment diagnostic intelligence into the application, using machine learning and artificial intelligence techniques to increase the accuracy of diagnosis, and a client-server based architecture of the application.

# Figures

![Pure tone audiogram interface.](puretone1.png)

![Impedance audiometry interface.](impedance1.png)

# References
