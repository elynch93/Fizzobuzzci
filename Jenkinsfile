def BuildSolution()
{
    powershell """cd 'C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin'
                  .\\MSBuild.exe %WORKSPACE%\\Fizzobuzzci.sln /p:Platform=%platform%,Platform=
                  Any CPU" """
}

pipeline
{
    agent none
    options
    {
        timeout(time: 120, unit: 'SECONDS')
    }

    stages
    {
        stage('Build Solution')
        {
            parallel
            {
                stage('Debug Build')
                {
                    agent any
                    steps
                    {
                        git(branch: env.BRANCH_NAME, credentialsId: 'b15ff232-f75e-413e-b391-0d2a72b85d54', url: 'https://github.com/elynch93/Fizzobuzzci')
                        BuildSolution('Debug')
                    }
                }

                stage('Release Build')
                {
                    agent any
                    steps
                    {
                        git(branch: env.BRANCH_NAME, credentialsId: 'b15ff232-f75e-413e-b391-0d2a72b85d54', url: 'https://github.com/elynch93/Fizzobuzzci')
                        BuildSolution('Release')
                    }
                }

                stage('Merge Testing')
                {
                    agent any
                    when
                    {
                        beforeAgent: true
                        anyOf
                        {
                            changeRequest target: 'main'
                            branch: 'main'
                        }
                    }
                    steps
                    {
                        // Do some testing to protect main branch (and when main branch has code merged to it).
                        echo('Placeholder testing...')
                    }
                }
            }
        }
    }
}