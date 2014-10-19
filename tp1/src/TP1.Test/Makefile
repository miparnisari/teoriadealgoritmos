
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/TP1.Test.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Debug/tp1.dll
BUILD_DIR = bin/Debug

TP1_TEST_DLL_MDB_SOURCE=bin/Debug/TP1.Test.dll.mdb
TP1_TEST_DLL_MDB=$(BUILD_DIR)/TP1.Test.dll.mdb
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

ifeq ($(CONFIG),DEBUG_MIXED_PLATFORMS)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/TP1.Test.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Debug/tp1.dll
BUILD_DIR = bin/Debug

TP1_TEST_DLL_MDB_SOURCE=bin/Debug/TP1.Test.dll.mdb
TP1_TEST_DLL_MDB=$(BUILD_DIR)/TP1.Test.dll.mdb
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/TP1.Test.dll
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Debug/tp1.dll
BUILD_DIR = bin/Debug

TP1_TEST_DLL_MDB_SOURCE=bin/Debug/TP1.Test.dll.mdb
TP1_TEST_DLL_MDB=$(BUILD_DIR)/TP1.Test.dll.mdb
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/TP1.Test.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Release/tp1.dll
BUILD_DIR = bin/Release

TP1_TEST_DLL_MDB=
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_MIXED_PLATFORMS)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/TP1.Test.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Release/tp1.dll
BUILD_DIR = bin/Release

TP1_TEST_DLL_MDB=
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize+
ASSEMBLY = bin/Release/TP1.Test.dll
ASSEMBLY_MDB = 
COMPILE_TARGET = library
PROJECT_REFERENCES =  \
	../TP1/bin/Release/tp1.dll
BUILD_DIR = bin/Release

TP1_TEST_DLL_MDB=
REALDATA_TXT_SOURCE=Input/realdata.txt
TEST_TXT_SOURCE=Input/test.txt
TP1_DLL_SOURCE=../TP1/bin/Debug/tp1.dll
TP1_DLL_MDB_SOURCE=../TP1/bin/Debug/tp1.dll.mdb

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(TP1_TEST_DLL_MDB) \
	$(TP1_DLL) \
	$(TP1_DLL_MDB)  

PROGRAMFILES_INPUT = \
	$(REALDATA_TXT) \
	$(TEST_TXT)  

LINUX_PKGCONFIG = \
	$(TP1_TEST_PC)  


RESGEN=resgen2

REALDATA_TXT = $(BUILD_DIR)/Input/realdata.txt
TEST_TXT = $(BUILD_DIR)/Input/test.txt
TP1_DLL = $(BUILD_DIR)/tp1.dll
TP1_DLL_MDB = $(BUILD_DIR)/tp1.dll.mdb
TP1_TEST_PC = $(BUILD_DIR)/tp1.test.pc

FILES = \
	GraphTest.cs \
	HeapTest.cs \
	ShortestPathsTest.cs \
	InfluencesTest.cs \
	StringGraphReader.cs \
	RecommendationsTest.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	Input/realdata.txt \
	packages.config \
	Input/test.txt \
	tp1.test.pc.in 

REFERENCES =  \
	-pkg:mono-nunit \
	System

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(PROGRAMFILES_INPUT) $(LINUX_PKGCONFIG) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(PROGRAMFILES_INPUT) $(LINUX_PKGCONFIG)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,REALDATA_TXT))
$(eval $(call emit-deploy-target,TEST_TXT))
$(eval $(call emit-deploy-target,TP1_DLL))
$(eval $(call emit-deploy-target,TP1_DLL_MDB))
$(eval $(call emit-deploy-wrapper,TP1_TEST_PC,tp1.test.pc))


$(eval $(call emit_resgen_targets))
$(build_xamlg_list): %.xaml.g.cs: %.xaml
	xamlg '$<'


$(ASSEMBLY_MDB): $(ASSEMBLY)
$(ASSEMBLY): $(build_sources) $(build_resources) $(build_datafiles) $(DLL_REFERENCES) $(PROJECT_REFERENCES) $(build_xamlg_list) $(build_satellite_assembly_list)
	make pre-all-local-hook prefix=$(prefix)
	mkdir -p $(shell dirname $(ASSEMBLY))
	make $(CONFIG)_BeforeBuild
	$(ASSEMBLY_COMPILER_COMMAND) $(ASSEMBLY_COMPILER_FLAGS) -out:$(ASSEMBLY) -target:$(COMPILE_TARGET) $(build_sources_embed) $(build_resources_embed) $(build_references_ref)
	make $(CONFIG)_AfterBuild
	make post-all-local-hook prefix=$(prefix)

install-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-install-local-hook prefix=$(prefix)
	make install-satellite-assemblies prefix=$(prefix)
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)'
	$(call cp,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TP1_TEST_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)/Input'
	$(call cp,$(REALDATA_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call cp,$(TEST_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call cp,$(TP1_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TP1_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/pkgconfig'
	$(call cp,$(TP1_TEST_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TP1_TEST_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(REALDATA_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call rm,$(TEST_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call rm,$(TP1_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TP1_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TP1_TEST_PC),$(DESTDIR)$(libdir)/pkgconfig)
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
