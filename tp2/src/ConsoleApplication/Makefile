
EXTRA_DIST =  Makefile

# Warning: This is an automatically generated file, do not edit!

srcdir=.
top_srcdir=..

include $(top_srcdir)/config.make

ifeq ($(CONFIG),DEBUG)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/ConsoleApplication.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Debug/TP2.dll
BUILD_DIR = bin/Debug

CONSOLEAPPLICATION_EXE_MDB_SOURCE=bin/Debug/ConsoleApplication.exe.mdb
CONSOLEAPPLICATION_EXE_MDB=$(BUILD_DIR)/ConsoleApplication.exe.mdb
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Debug/TP2.dll
TP2_DLL_MDB_SOURCE=../TP2/bin/Debug/TP2.dll.mdb
TP2_DLL_MDB=$(BUILD_DIR)/TP2.dll.mdb

endif

ifeq ($(CONFIG),DEBUG_MIXED_PLATFORMS)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/ConsoleApplication.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Debug/TP2.dll
BUILD_DIR = bin/Debug

CONSOLEAPPLICATION_EXE_MDB_SOURCE=bin/Debug/ConsoleApplication.exe.mdb
CONSOLEAPPLICATION_EXE_MDB=$(BUILD_DIR)/ConsoleApplication.exe.mdb
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Debug/TP2.dll
TP2_DLL_MDB_SOURCE=../TP2/bin/Debug/TP2.dll.mdb
TP2_DLL_MDB=$(BUILD_DIR)/TP2.dll.mdb

endif

ifeq ($(CONFIG),DEBUG_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize- -debug "-define:DEBUG;"
ASSEMBLY = bin/Debug/ConsoleApplication.exe
ASSEMBLY_MDB = $(ASSEMBLY).mdb
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Debug/TP2.dll
BUILD_DIR = bin/Debug

CONSOLEAPPLICATION_EXE_MDB_SOURCE=bin/Debug/ConsoleApplication.exe.mdb
CONSOLEAPPLICATION_EXE_MDB=$(BUILD_DIR)/ConsoleApplication.exe.mdb
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Debug/TP2.dll
TP2_DLL_MDB_SOURCE=../TP2/bin/Debug/TP2.dll.mdb
TP2_DLL_MDB=$(BUILD_DIR)/TP2.dll.mdb

endif

ifeq ($(CONFIG),RELEASE)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/ConsoleApplication.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Release/TP2.dll
BUILD_DIR = bin/Release

CONSOLEAPPLICATION_EXE_MDB=
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Release/TP2.dll
TP2_DLL_MDB=

endif

ifeq ($(CONFIG),RELEASE_MIXED_PLATFORMS)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/ConsoleApplication.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Release/TP2.dll
BUILD_DIR = bin/Release

CONSOLEAPPLICATION_EXE_MDB=
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Release/TP2.dll
TP2_DLL_MDB=

endif

ifeq ($(CONFIG),RELEASE_X86)
ASSEMBLY_COMPILER_COMMAND = dmcs
ASSEMBLY_COMPILER_FLAGS =  -noconfig -codepage:utf8 -warn:4 -optimize-
ASSEMBLY = bin/Release/ConsoleApplication.exe
ASSEMBLY_MDB = 
COMPILE_TARGET = exe
PROJECT_REFERENCES =  \
	../TP2/bin/Release/TP2.dll
BUILD_DIR = bin/Release

CONSOLEAPPLICATION_EXE_MDB=
PUNTO1_TXT_SOURCE=Input/punto1.txt
PUNTO2_TXT_SOURCE=Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG_SOURCE=App.config
TP2_DLL_SOURCE=../TP2/bin/Release/TP2.dll
TP2_DLL_MDB=

endif

AL=al
SATELLITE_ASSEMBLY_NAME=$(notdir $(basename $(ASSEMBLY))).resources.dll

PROGRAMFILES = \
	$(CONSOLEAPPLICATION_EXE_MDB) \
	$(CONSOLEAPPLICATION_EXE_CONFIG) \
	$(TP2_DLL) \
	$(TP2_DLL_MDB)  

PROGRAMFILES_INPUT = \
	$(PUNTO1_TXT) \
	$(PUNTO2_TXT)  

BINARIES = \
	$(CONSOLEAPPLICATION)  


RESGEN=resgen2

PUNTO1_TXT = $(BUILD_DIR)/Input/punto1.txt
PUNTO2_TXT = $(BUILD_DIR)/Input/punto2.txt
CONSOLEAPPLICATION_EXE_CONFIG = $(BUILD_DIR)/ConsoleApplication.exe.config
TP2_DLL = $(BUILD_DIR)/TP2.dll
CONSOLEAPPLICATION = $(BUILD_DIR)/consoleapplication

FILES = \
	Logger.cs \
	Main.cs \
	AssemblyInfo.cs 

DATA_FILES = 

RESOURCES = 

EXTRAS = \
	App.config \
	Input/punto1.txt \
	Input/punto2.txt \
	consoleapplication.in 

REFERENCES =  \
	System \
	System.Configuration

DLL_REFERENCES = 

CLEANFILES = $(PROGRAMFILES) $(PROGRAMFILES_INPUT) $(BINARIES) 

#Targets
all: $(ASSEMBLY) $(PROGRAMFILES) $(PROGRAMFILES_INPUT) $(BINARIES)  $(top_srcdir)/config.make

include $(top_srcdir)/Makefile.include
#include $(srcdir)/custom-hooks.make



$(eval $(call emit-deploy-target,PUNTO1_TXT))
$(eval $(call emit-deploy-target,PUNTO2_TXT))
$(eval $(call emit-deploy-target,CONSOLEAPPLICATION_EXE_CONFIG))
$(eval $(call emit-deploy-target,TP2_DLL))
$(eval $(call emit-deploy-target,TP2_DLL_MDB))
$(eval $(call emit-deploy-wrapper,CONSOLEAPPLICATION,consoleapplication,x))


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
	$(call cp,$(CONSOLEAPPLICATION_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(libdir)/$(PACKAGE)/Input'
	$(call cp,$(PUNTO1_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call cp,$(PUNTO2_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call cp,$(CONSOLEAPPLICATION_EXE_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TP2_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call cp,$(TP2_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	mkdir -p '$(DESTDIR)$(bindir)'
	$(call cp,$(CONSOLEAPPLICATION),$(DESTDIR)$(bindir))
	make post-install-local-hook prefix=$(prefix)

uninstall-local: $(ASSEMBLY) $(ASSEMBLY_MDB)
	make pre-uninstall-local-hook prefix=$(prefix)
	make uninstall-satellite-assemblies prefix=$(prefix)
	$(call rm,$(ASSEMBLY),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(ASSEMBLY_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(CONSOLEAPPLICATION_EXE_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(PUNTO1_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call rm,$(PUNTO2_TXT),$(DESTDIR)$(libdir)/$(PACKAGE)/Input)
	$(call rm,$(CONSOLEAPPLICATION_EXE_CONFIG),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TP2_DLL),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(TP2_DLL_MDB),$(DESTDIR)$(libdir)/$(PACKAGE))
	$(call rm,$(CONSOLEAPPLICATION),$(DESTDIR)$(bindir))
	make post-uninstall-local-hook prefix=$(prefix)

install: install-local
uninstall: uninstall-local
clean: clean-local

include $(top_srcdir)/rules.make
