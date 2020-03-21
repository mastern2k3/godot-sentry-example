DIR := $(shell dirname $(realpath $(lastword $(MAKEFILE_LIST))))

MONO := mono
PROTOC := protoc
NUGET := nuget.exe
MSBUILD := msbuild
GODOT := godot
BUILD_FOLDER := build

.PHONY: all editor build restore run clean

all: build

editor:
	$(GODOT) -e &

build: restore
	cd $(DIR); \
	$(MSBUILD) /t:build

build-csharp:
	cd $(DIR); \
	$(GODOT) --build-solutions -q

restore:
	$(MONO) $(NUGET) restore

debug:
	cd $(DIR)
	$(GODOT) --debug-collisions

run:
	cd $(DIR)
	$(GODOT)

clean:
	cd $(DIR)
	$(MSBUILD) /t:clean
