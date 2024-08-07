========================= startttttttttttttttttttt
### [Journal of Nondestructive Evaluation 38.3 (2019)]
<h1 align="center">
<a href=https://link.springer.com/article/10.1007/s10921-019-0601-x>Real-Time Video Surveillance Based Structural Health Monitoring of Civil Structures Using Artificial Neural Network</a>
</h1>

<p>
<div align="center">
    Moushumi Medhi<sup>1</sup> 
    &middot;
    Aradhana Dandautiya<sup>1</sup> 
    &middot;
    <a href="https://scholar.google.co.in/citations?user=MZkfoWoAAAAJ&hl=en">Jagdish Lal Raheja</a><sup>1</sup> 
</div>
<div align="center">
  <sup>1</sup>  CSIR-Central Electronics Engineering Research Institute, Pilani, Rajasthan 333031, India.<br>
  <a href="https://link.springer.com/article/10.1007/s10921-019-0601-x">[Paper]</a><br>
    <a href="https://youtu.be/mekb40luapE">[Demo]</a>....CHANGE THIS
</div>
</p>

![teaser](images/teaser.png)

[![Full Demo](https://img.shields.io/badge/Full%20Demo-YouTube-b31b1b)](https://youtu.be/mekb40luapE)

This is the official repository of the paper titled "Real-Time Video Surveillance Based Structural Health Monitoring of Civil Structures Using Artificial Neural Network".



We present a computer vision based non-destructive structural health monitoring (SHM) method using high speed video imaging system. We trained an artificial neural network to infer the qualitative characteristics of structural vibrations based on vibration intensity. The efficacy of our vision system in remote measurement of dynamic displacements was demonstrated through laboratory experiments (e.g., shaking table, slip desk)".


## 🚀 Updates
- Stay tuned for our code release!


## Table of Contents
* [Requirements](#requirements)
* [Setup](#setup)
* [Citation](#citation)


## Requirements
* Python 3.10
* Docker


## Setup

1. Clone this `amodal` repository, and run `cd Grounded-Segment-Anything`.

2. In the Dockerfile, change all instances of `/home/appuser` to your path for the `amodal` repository.

3. Run `make build-image`.

4. Start and attach to a docker container from the image `gsa:v0`. Then, navigate to the `amodal` repository.

5. Run `./install.sh` to finish setup and download model checkpoints.


## Dataset

1. Run `./download_dataset.sh` to download the COCO dataset.


## Usage

### Progressive Occlusion-aware Completion Pipeline

1. In `./main.sh`, modify `input_dir` to your folder path for the images.

2. Run `./main.sh`. You may need to use `chmod` to change the file permissions first.


## Citation

If you find our work useful, please cite our paper:
```
@inproceedings{xu2024amodal,
  title={Amodal completion via progressive mixed context diffusion},
  author={Xu, Katherine and Zhang, Lingzhi and Shi, Jianbo},
  booktitle={Proceedings of the IEEE/CVF Conference on Computer Vision and Pattern Recognition},
  pages={9099--9109},
  year={2024}
}
```

aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa start

This repository provides the evaluation code for our WACV 2023 [paper](https://openaccess.thecvf.com/content/WACV2023/html/Conti_Sparsity_Agnostic_Depth_Completion_WACV_2023_paper.html).

We present a novel depth completion approach agnostic to the sparsity of depth points, that is very likely to vary in many practical applications. State-of-the-art approaches yield accurate results only when processing a specific density and distribution of input points, i.e. the one observed during training, narrowing their deployment in real use cases. On the contrary, our solution is robust to uneven distributions and extremely low densities never witnessed during training. Experimental results on standard indoor and outdoor benchmarks highlight the robustness of our framework, achieving accuracy comparable to state-of-the-art methods when tested with density and distribution equal to the training one while being much more accurate in the other cases.

## Citation

```
@InProceedings{Conti_2023_WACV,
    author    = {Conti, Andrea and Poggi, Matteo and Mattoccia, Stefano},
    title     = {Sparsity Agnostic Depth Completion},
    booktitle = {Proceedings of the IEEE/CVF Winter Conference on Applications of Computer Vision (WACV)},
    month     = {January},
    year      = {2023},
    pages     = {5871-5880}
}
```

## Qualitative Results

To better visualize the performance of our proposal we provide a simple [streamlit](https://streamlit.io) application, which can be executed in the following way:

```bash
$ git clone https://github.com/andreaconti/sparsity-agnostic-depth-Completion
$ cd sparsity-agnostic-depth-Completion
$ mamba env create -f environment.yml
$ mamba activate sparsity-agnostic-depth-Completion
$ streamlit run visualize.py
```

![](https://github.com/andreaconti/sparsity-agnostic-depth-completion/blob/master/readme_assets/visualize-demo.gif)

It may take a while when you change dataset or hints density to display since it have to download and unpack the data.

## Quantitative Results

We provide precomputed depth maps for [KITTI Depth Completion](https://github.com/andreaconti/sparsity-agnostic-depth-completion/releases/download/v0.1.0/kitti-official.tar) and [NYU Depth V2](https://github.com/andreaconti/sparsity-agnostic-depth-completion/releases/download/v0.1.0/nyu-depth-v2-ma-downsampled.tar), with different sparsity patterns.

Moreover we provide a simple evaluation script to compute metrics:

```bash
$ git clone https://github.com/andreaconti/sparsity-agnostic-depth-Completion
$ cd sparsity-agnostic-depth-Completion
$ mamba env create -f environment.yml
$ mamba activate sparsity-agnostic-depth-Completion
$ python evaluate.py <kitti-official | nyu-depth-v2-ma-downsampled> <hints density>
```

For instance:

```bash
# KITTI evaluation
$ python evaluate.py kitti-official lines64
# NYU Depth V2 evaluation
$ python evaluate.py nyu-depth-v2-ma-downsampled 500
```
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa end
=============================== enddddddddddddddddddddddddddd
## License
All rights reserved. No part of this project may be mirrored, reproduced, borrowed, altered, distributed, or transmitted in any form or by any means, including photocopying, recording, or other electronic or mechanical methods, without the prior written permission of the authors.
